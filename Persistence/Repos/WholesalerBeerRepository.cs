using Domain.Models;
using Domain.Repos;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Persistence.Repos
{
    public class WholesalerBeerRepository : Repository<WholesalerBeer>, IWholesalerBeerRepository
    {
        private DataContext _context;

        public WholesalerBeerRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<WholesalerBeer> GetAsync(int wholesalerId, int beerId)
        {
            return await _context.WholesalerBeers
                .Include(x => x.Wholesaler)
                .Include(x => x.Beer)
                .Where(x => x.WholesalerId == wholesalerId && x.BeerId == beerId)
                .FirstOrDefaultAsync();
        }
    }
}