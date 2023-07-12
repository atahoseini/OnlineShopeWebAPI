namespace OnlineShop.Infrastructure
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public long Price { get; set; }
        public string? PriceWithComma { get; set; }
    }
}