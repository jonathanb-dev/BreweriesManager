using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class Beer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Column(TypeName = "decimal(7, 2)")]
        public decimal Price { get; set; }
        public Brewery Brewery { get; set; }
        public ICollection<WholesalerBeer> WholesalerBeers { get; set; }
    }
}