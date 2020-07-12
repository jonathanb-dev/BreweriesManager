using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class PutWholesalerDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Wholesaler name is required")]
        public string Name { get; set; }
    }
}