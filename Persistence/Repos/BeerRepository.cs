using Domain.Models;
using Domain.Repos;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persistence.Repos
{
    public class BeerRepository : Repository<Beer>, IBeerRepository
    {
        private DataContext _context;

        public BeerRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Beer>> BreweriesAndWholesalersListAsync()
        {
            return await _context.Beers
                .Include(x => x.Brewery)
                .Include(x => x.WholesalerBeers)
                .ThenInclude(x => x.Wholesaler)
                .ToListAsync();
        }

        public async Task<IEnumerable<Beer>> PricesListAsync(List<int> beerIds)
        {
            /*return await _context.Beers
                .Join(beerIds, b => b.Id, beerId => beerId, (b, beerId) => b)
                .ToListAsync();*/

            return await _context.Beers.Where(x => beerIds.Contains(x.Id)).ToListAsync();
        }

        public async Task<Beer> WholesalerBeersGetAsync(int id)
        {
            return await _context.Beers
                .Include(x => x.WholesalerBeers)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}