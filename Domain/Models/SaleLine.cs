using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    [Table("SaleLines")]
    public class SaleLine
    {
        public int Id { get; set; }
        public SaleHeader SaleHeader { get; set; }
        public Beer Beer { get; set; }
        public int Quantity { get; set; }
        [Column(TypeName = "decimal(7, 2)")]
        public decimal UnitPrice { get; set; }
        [Column(TypeName = "decimal(3, 2)")]
        public decimal DiscountRate { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalNetVatExcluded { get; set; }

        public SaleLine()
        {
            Quantity = 0;
            UnitPrice = 0;
            DiscountRate = 0;
            TotalNetVatExcluded = 0;
        }
    }
}