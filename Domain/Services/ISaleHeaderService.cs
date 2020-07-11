using Domain.Models;

namespace Domain.Services
{
    public interface ISaleHeaderService : IService<SaleHeader>
    {
        void Validate(SaleHeader saleHeader);
        void Compute(SaleHeader saleHeader);
    }
}