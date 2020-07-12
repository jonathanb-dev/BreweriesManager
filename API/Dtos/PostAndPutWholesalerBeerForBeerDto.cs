using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class PostAndPutWholesalerBeerForBeerDto
    {
        public int WholesalerId { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Stock must be greater or equal to 0")]
        public int Stock { get; set; }
    }
}