using Domain.Models;
using System.Collections.Generic;

namespace API.Dtos
{
    public class SaleHeaderDto
    {
        public int Id { get; set; }
        public WholesalerDto wholesaler { get; set; }
        public decimal TotalVatExcluded { get; set; }
        public ICollection<SaleLineDto> SaleLines { get; set; }
    }
}