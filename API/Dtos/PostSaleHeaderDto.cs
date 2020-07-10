using System.Collections.Generic;

namespace API.Dtos
{
    public class PostSaleHeaderDto
    {
        public int WholeSalerId { get; set; }
        public List<PostSaleLineDto> SaleLines { get; set; }
    }
}