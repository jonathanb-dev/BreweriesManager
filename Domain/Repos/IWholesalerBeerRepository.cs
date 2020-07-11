using Domain.Models;
using System.Threading.Tasks;

namespace Domain.Repos
{
    public interface IWholesalerBeerRepository : IRepository<WholesalerBeer>
    {
        Task<WholesalerBeer> GetAsync(int wholesalerId, int beerId);
    }
}