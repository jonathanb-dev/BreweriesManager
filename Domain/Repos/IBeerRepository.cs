using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Repos
{
    public interface IBeerRepository : IRepository<Beer>
    {
        Task<Beer> WholesalerBeersGetAsync(int id);
        Task<IEnumerable<Beer>> BreweriesAndWholesalersListAsync();
        Task<IEnumerable<Beer>> PricesListAsync(List<int> beerIds);
    }
}