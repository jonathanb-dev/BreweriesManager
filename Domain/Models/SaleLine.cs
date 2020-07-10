using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class SaleLine
    {
        public int Id { get; set; }
        public SaleHeader SaleHeader { get; set; }
        public Beer Beer { get; set; }
        [Column(TypeName = "decimal(5, 0)")]
        public decimal Quantity { get; set; }
        [Column(TypeName = "decimal(7, 2)")]
        public decimal UnitPrice { get; set; }
        [Column(TypeName = "decimal(3, 2)")]
        public decimal DiscountRate { get; set; }
    }
}