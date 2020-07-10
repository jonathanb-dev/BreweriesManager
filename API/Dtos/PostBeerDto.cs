namespace API.Dtos
{
    public class PostBeerDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int BreweryId { get; set; }
    }
}