using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Repos
{
    public interface IWholesalerBeerRepository : IRepository<WholesalerBeer>
    {
        Task<IEnumerable<WholesalerBeer>> ListByWholesalerIdAsync(int wholesalerId);
        Task<WholesalerBeer> GetAsync(int wholesalerId, int beerId);
    }
}