using Domain;

namespace Persistence.Repos
{
    class WholesalerRepository : Repository<Wholesaler>, IWholesalerRepository
    {
        private DataContext _context;

        public WholesalerRepository(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}