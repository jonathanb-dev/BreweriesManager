using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class PutBeerDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Beer name is required")]
        public string Name { get; set; }
        [Range(0.01, double.MaxValue, ErrorMessage = "Beer price must be greater than 0")]
        public decimal Price { get; set; }
        public int BreweryId { get; set; }
    }
}