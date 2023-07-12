using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Core
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(128), Required]
        public string? ProductName { get; set; }
        public long Price { get; set; }
    }

}