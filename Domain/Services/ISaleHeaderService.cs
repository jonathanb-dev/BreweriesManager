using Domain.Models;
using System.Threading.Tasks;

namespace Domain.Services
{
    public interface ISaleHeaderService : IService<SaleHeader>
    {
        Task Validate(SaleHeader saleHeader);
        Task Compute(SaleHeader saleHeader);
    }
}