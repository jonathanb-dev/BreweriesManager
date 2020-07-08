using System.Collections.Generic;

namespace Domain
{
    public class Brewery
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Beer> Beers { get; set; }
    }
}