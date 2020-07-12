using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Services
{
    public interface IBeerService : IService<Beer>
    {
        Task<Beer> WholesalerBeersGetAsync(int id);
        Task<IEnumerable<Beer>> BreweriesAndWholesalersListAsync();
    }
}