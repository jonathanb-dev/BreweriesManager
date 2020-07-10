using Domain.Models;
using System.Collections.Generic;

namespace API.Dtos
{
    public class SaleHeaderDto
    {
        public int Id { get; set; }
        public Wholesaler wholesaler { get; set; }
        public ICollection<SaleLine> SaleLines { get; set; }
    }
}