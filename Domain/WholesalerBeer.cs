using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    class WholesalerBeer
    {
        [Key, Column(Order = 0)]
        public int WholesalerId { get; set; }
        [Key, Column(Order = 1)]
        public int BeerId { get; set; }
        public int Stock { get; set; }
        public Wholesaler Wholesaler { get; set; }
        public Beer Beer { get; set; }
    }
}