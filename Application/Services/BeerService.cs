using Domain.Models;
using Domain.Repos;
using Domain.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class BeerService : IBeerService
    {
        private readonly IBeerRepository _repo;

        public BeerService(IBeerRepository repo)
        {
            _repo = repo;
        }

        public void Add(Beer entity)
        {
            _repo.Add(entity);
        }

        public async Task<IEnumerable<Beer>> BreweriesAndWholesalersListAsync()
        {
            return await _repo.BreweriesAndWholesalersListAsync();
        }

        public void Delete(int id)
        {
            _repo.Delete(id);
        }

        public async Task<Beer> GetAsync(int id)
        {
            return await _repo.GetAsync(id);
        }

        public async Task<IEnumerable<Beer>> ListAsync()
        {
            return await _repo.ListAsync();
        }

        public async Task<bool> SaveAsync()
        {
            return await _repo.SaveAsync();
        }

        public void Update(Beer entity)
        {
            _repo.Update(entity);
        }
    }
}