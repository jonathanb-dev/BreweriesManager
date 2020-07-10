using System.Collections.Generic;

namespace Domain.Models
{
    public class Wholesaler
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<WholesalerBeer> WholesalerBeers { get; set; }
        public ICollection<SaleHeader> SaleHeaders { get; set; }
    }
}