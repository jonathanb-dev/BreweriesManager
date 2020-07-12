using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Domain.Models
{
    public class SaleHeader
    {
        public int Id { get; set; }
        public int WholesalerId { get; set; }
        public Wholesaler Wholesaler { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalVatExcluded { get; set; }
        public ICollection<SaleLine> SaleLines { get; set; }

        public SaleHeader()
        {
            TotalVatExcluded = 0M;
        }

        public void Compute()
        {
            decimal totalVatExcluded = 0M;
            decimal discountRate = GetDiscountRate();

            foreach (SaleLine saleLine in SaleLines)
            {
                saleLine.DiscountRate = discountRate;

                totalVatExcluded += saleLine.TotalNetVatExcluded = (saleLine.Quantity * saleLine.UnitPrice) * (1 - saleLine.DiscountRate);
            }

            TotalVatExcluded = totalVatExcluded;
        }

        private decimal GetDiscountRate()
        {
            decimal discountRate = 0M;

            int totalQuantity = SaleLines
                .AsEnumerable()
                .Sum(x => x.Quantity);

            if (totalQuantity > 10)
            {
                discountRate = 0.1M;
            }

            if (totalQuantity > 20)
            {
                discountRate = 0.2M;
            }

            return discountRate;
        }
    }
}