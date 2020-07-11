namespace API.Dtos
{
    public class SaleLineDto
    {
        public int Id { get; set; }
        public BeerForSaleLineDto Beer { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal DiscountRate { get; set; }
        public decimal TotalNetVatExcluded { get; set; }
    }
}