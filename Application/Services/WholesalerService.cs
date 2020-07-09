using Domain.Models;
using Domain.Repos;
using Domain.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class WholesalerService : IWholesalerService
    {
        private readonly IWholesalerRepository _repo;

        public WholesalerService(IWholesalerRepository repo)
        {
            _repo = repo;
        }

        public void Add(Wholesaler entity)
        {
            _repo.Add(entity);
        }

        public void Delete(int id)
        {
            _repo.Delete(id);
        }

        public async Task<Wholesaler> GetAsync(int id)
        {
            return await _repo.GetAsync(id);
        }

        public async Task<IEnumerable<Wholesaler>> ListAsync()
        {
            return await _repo.ListAsync();
        }

        public async Task<bool> SaveAsync()
        {
            return await _repo.SaveAsync();
        }

        public void Update(Wholesaler entity)
        {
            _repo.Update(entity);
        }
    }
}