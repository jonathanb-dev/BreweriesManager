using Domain.Models;
using Domain.Repos;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Application.Services
{
    public class SaleHeaderService : ISaleHeaderService
    {
        private readonly ISaleHeaderRepository _saleHeaderRepo;
        private readonly IBeerRepository _beerRepository;
        private readonly IWholesalerBeerRepository _wholesalerBeerRepo;

        public SaleHeaderService(ISaleHeaderRepository saleHeaderRepo, IBeerRepository beerRepository, IWholesalerBeerRepository wholesalerBeerRepo)
        {
            _saleHeaderRepo = saleHeaderRepo;
            _beerRepository = beerRepository;
            _wholesalerBeerRepo = wholesalerBeerRepo;
        }

        public void Add(SaleHeader entity)
        {
            _saleHeaderRepo.Add(entity);
        }

        public async Task Compute(SaleHeader saleHeader)
        {
            List<Beer> beers = (await _beerRepository.PricesListAsync(saleHeader.SaleLines.AsEnumerable().Select(x => x.BeerId).ToList())).ToList();

            foreach (SaleLine saleLine in saleHeader.SaleLines)
            {
                saleLine.UnitPrice = beers.AsEnumerable().Where(x => x.Id == saleLine.BeerId).First().Price;
            }

            saleHeader.Compute();
        }

        public void Delete(int id)
        {
            _saleHeaderRepo.Delete(id);
        }

        public async Task<SaleHeader> GetAsync(int id)
        {
            return await _saleHeaderRepo.GetAsync(id);
        }

        public async Task<IEnumerable<SaleHeader>> ListAsync()
        {
            return await _saleHeaderRepo.ListAsync();
        }

        public async Task<bool> SaveAsync()
        {
            return await _saleHeaderRepo.SaveAsync();
        }

        public void Update(SaleHeader entity)
        {
            _saleHeaderRepo.Update(entity);
        }

        public async Task Validate(SaleHeader saleHeader)
        {
            if (saleHeader.SaleLines.Count == 0)
            {
                throw new Exception("Add at least one document line");
            }

            if (saleHeader.SaleLines
                .AsEnumerable()
                .GroupBy(x => x.BeerId)
                .Where(g => g.Count() > 1)
                .Any()
            )
            {
                throw new Exception("Duplicate beers are not allowed");
            }

            List<WholesalerBeer> wholesalerBeers = (await _wholesalerBeerRepo.ListByWholesalerIdAsync(saleHeader.WholesalerId)).ToList();

            List<int> beersNotAvailable = saleHeader.SaleLines
                .AsEnumerable()
                .Where(sl => wholesalerBeers
                    .All(wb => wb.BeerId != sl.BeerId || wb.Stock < sl.Quantity)
                )
                .Select(x => x.BeerId)
                .ToList();

            if (beersNotAvailable.Count > 0)
            {
                throw new Exception("Following beer ids are not available at this wholesaler or are out of stock: " + String.Join(", ", beersNotAvailable));
            }
        }
    }
}