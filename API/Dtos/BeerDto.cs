using System.Collections.Generic;

namespace API.Dtos
{
    public class BeerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public BreweryDto Brewery { get; set; }
        public ICollection<WholesalerBeerForBeerDto> WholesalerBeers { get; set; }
    }
}