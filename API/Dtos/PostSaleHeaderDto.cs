using System.Collections.Generic;

namespace API.Dtos
{
    public class PostSaleHeaderDto
    {
        public int WholeSalerId { get; set; }
        public ICollection<PostSaleLineDto> SaleLines { get; set; }
    }
}