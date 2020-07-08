using Domain.Models;
using Domain.Repos;

namespace Persistence.Repos
{
    public class BreweryRepository : Repository<Brewery>, IBreweryRepository
    {
        private DataContext _context;

        public BreweryRepository(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}