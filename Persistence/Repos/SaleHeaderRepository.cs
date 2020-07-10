using Domain.Models;
using Domain.Repos;

namespace Persistence.Repos
{
    public class SaleHeaderRepository : Repository<SaleHeader>, ISaleHeaderRepository
    {
        private DataContext _context;

        public SaleHeaderRepository(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}