using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class PostSaleLineDto
    {
        public int BeerId { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater or equal to 1")]
        public int Quantity { get; set; }
    }
}