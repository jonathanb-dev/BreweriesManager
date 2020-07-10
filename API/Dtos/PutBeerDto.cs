namespace API.Dtos
{
    public class PutBeerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int BreweryId { get; set; }
    }
}