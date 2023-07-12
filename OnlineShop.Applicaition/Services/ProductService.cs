using Microsoft.EntityFrameworkCore;
using OnlineShop.Core;
using OnlineShop.Infrastructure;

namespace OnlineShop.Applicaition
{
    public class ProductService : IProductService
    {
        private readonly OnlineShopDbContext dbContext;

        //repository => dbcontext directly - unit_of_work

        public ProductService(OnlineShopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<ProductDto> Add(ProductDto model)
        {
            var product = new Product
            {
                Id = model.Id,
                Price = model.Price,
                ProductName = model.ProductName
            };
            await dbContext.Products.AddAsync(product);
            await dbContext.SaveChangesAsync();
            model.Id = product.Id;
            return model;
        }

        public async Task<ProductDto> Get(int id)
        {
            var product = await dbContext.Products.FindAsync(id);
            var model = new ProductDto
            {
                Id = product.Id,
                Price = product.Price,
                PriceWithComma = product.Price.ToString("###.###"),
                ProductName = product.ProductName
            };
            return model;
        }

        public async Task<List<ProductDto>> Getall()
        {
            var result = await dbContext.Products.Select(Product => new ProductDto
            {
                Id = Product.Id,
                Price = Product.Price,
                ProductName = Product.ProductName,
                PriceWithComma = Product.Price.ToString("###.###")
            }).ToListAsync();
            return result;
        }
    }

}