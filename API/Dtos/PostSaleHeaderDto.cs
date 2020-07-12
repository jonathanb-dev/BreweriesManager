using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class PostSaleHeaderDto
    {
        public int WholeSalerId { get; set; }
        [Required(ErrorMessage = "At least one document line is required")]
        public ICollection<PostSaleLineDto> SaleLines { get; set; }
    }
}