using System.Collections.Generic;

namespace Domain
{
    public class Beer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Brewery Brewery { get; set; }
        public ICollection<Wholesaler> Wholesalers { get; set; }
    }
}