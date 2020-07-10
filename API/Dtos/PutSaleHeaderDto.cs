using System.Collections.Generic;

namespace API.Dtos
{
    public class PutSaleHeaderDto
    {
        public int Id { get; set; }
        public int WholeSalerId { get; set; }
        public List<PostSaleLineDto> SaleLines { get; set; }
    }
}