using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    [Table("WholesalerBeers")]
    public class WholesalerBeer
    {
        public int WholesalerId { get; set; }
        public Wholesaler Wholesaler { get; set; }
        public int BeerId { get; set; }
        public Beer Beer { get; set; }
        public int Stock { get; set; }
    }
}