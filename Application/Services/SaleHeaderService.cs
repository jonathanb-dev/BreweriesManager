using Domain.Models;
using Domain.Repos;
using Domain.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class SaleHeaderService : ISaleHeaderService
    {
        private readonly ISaleHeaderRepository _repo;

        public SaleHeaderService(ISaleHeaderRepository repo)
        {
            _repo = repo;
        }

        public void Add(SaleHeader entity)
        {
            _repo.Add(entity);
        }

        public void Delete(int id)
        {
            _repo.Delete(id);
        }

        public async Task<SaleHeader> GetAsync(int id)
        {
            return await _repo.GetAsync(id);
        }

        public async Task<IEnumerable<SaleHeader>> ListAsync()
        {
            return await _repo.ListAsync();
        }

        public async Task<bool> SaveAsync()
        {
            return await _repo.SaveAsync();
        }

        public void Update(SaleHeader entity)
        {
            _repo.Update(entity);
        }
    }
}