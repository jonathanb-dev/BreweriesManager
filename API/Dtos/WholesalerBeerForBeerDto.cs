namespace API.Dtos
{
    public class WholesalerBeerForBeerDto
    {
        public int WholesalerId { get; set; }
        public WholesalerDto Wholesaler { get; set; }
        public int Stock { get; set; }
    }
}