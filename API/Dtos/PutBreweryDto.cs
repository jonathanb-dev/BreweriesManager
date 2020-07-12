using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class PutBreweryDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Brewery name is required")]
        public string Name { get; set; }
    }
}