using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class PostWholesalerDto
    {
        [Required(ErrorMessage = "Wholesaler name is required")]
        public string Name { get; set; }
    }
}