using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class PostBreweryDto
    {
        [Required(ErrorMessage = "Brewery name is required")]
        public string Name { get; set; }
    }
}