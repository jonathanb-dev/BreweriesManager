namespace API.Dtos
{
    public class WholesalerBeerDto
    {
        public int WholesalerId { get; set; }
        public WholesalerDto Wholesaler { get; set; }
        public int BeerId { get; set; }
        public BeerForWholesalerBeerDto Beer { get; set; }
        public int Stock { get; set; }
    }
}