using Domain.Models;
using System.Threading.Tasks;

namespace Domain.Services
{
    public interface IWholesalerBeerService : IService<WholesalerBeer>
    {
        Task<WholesalerBeer> GetAsync(int wholesalerId, int beerId);
    }
}