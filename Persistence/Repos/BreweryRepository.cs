using Domain;

namespace Persistence.Repos
{
    class BreweryRepository : Repository<Brewery>, IBreweryRepository
    {
        private DataContext _context;

        public BreweryRepository(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}