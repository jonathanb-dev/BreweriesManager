using Domain.Models;
using Domain.Repos;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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
    }
}