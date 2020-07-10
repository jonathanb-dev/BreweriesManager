using System.Collections.Generic;

namespace Domain.Models
{
    public class SaleHeader
    {
        public int Id { get; set; }
        public Wholesaler Wholesaler { get; set; }
        public ICollection<SaleLine> SaleLines { get; set; }
    }
}