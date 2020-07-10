using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Repos
{
    public interface IBeerRepository : IRepository<Beer>
    {
        Task<IEnumerable<Beer>> BreweriesAndWholesalersListAsync();
    }
}