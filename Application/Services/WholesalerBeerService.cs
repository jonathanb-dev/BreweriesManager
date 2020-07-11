using Domain.Models;
using Domain.Repos;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class WholesalerBeerService : IWholesalerBeerService
    {
        private readonly IWholesalerBeerRepository _repo;

        public WholesalerBeerService(IWholesalerBeerRepository repo)
        {
            _repo = repo;
        }

        public void Add(WholesalerBeer entity)
        {
            _repo.Add(entity);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<WholesalerBeer> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<WholesalerBeer> GetAsync(int wholesalerId, int beerId)
        {
            return _repo.GetAsync(wholesalerId, beerId);
        }

        public Task<IEnumerable<WholesalerBeer>> ListAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SaveAsync()
        {
            return await _repo.SaveAsync();
        }

        public void Update(WholesalerBeer entity)
        {
            _repo.Update(entity);
        }
    }
}