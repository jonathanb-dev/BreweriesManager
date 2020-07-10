namespace API.Dtos
{
    public class WholesalerBeersDto
    {
        public int WholesalerId { get; set; }
        public WholesalerDto Wholesaler { get; set; }
        public int Stock { get; set; }
    }
}