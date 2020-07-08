using Domain.Models;
using Domain.Repos;

namespace Persistence.Repos
{
    public class WholesalerRepository : Repository<Wholesaler>, IWholesalerRepository
    {
        private DataContext _context;

        public WholesalerRepository(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}