using Domain.Models;
using Domain.Repos;
using Domain.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class BreweryService : IBreweryService
    {
        private readonly IBreweryRepository _repo;

        public BreweryService(IBreweryRepository repo)
        {
            _repo = repo;
        }

        public void Add(Brewery entity)
        {
            _repo.Add(entity);
        }

        public void Delete(int id)
        {
            _repo.Delete(id);
        }

        public async Task<Brewery> GetAsync(int id)
        {
            return await _repo.GetAsync(id);
        }

        public async Task<IEnumerable<Brewery>> ListAsync()
        {
            return await _repo.ListAsync();
        }

        public async Task<bool> SaveAsync()
        {
            return await _repo.SaveAsync();
        }

        public void Update(Brewery entity)
        {
            _repo.Update(entity);
        }
    }
}