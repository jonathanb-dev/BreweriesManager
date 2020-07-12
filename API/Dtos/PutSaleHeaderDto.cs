using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class PutSaleHeaderDto
    {
        public int Id { get; set; }
        public int WholeSalerId { get; set; }
        [Required(ErrorMessage = "At least one document line is required")]
        public List<PostSaleLineDto> SaleLines { get; set; }
    }
}