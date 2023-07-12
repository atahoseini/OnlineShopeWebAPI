using OnlineShop.Infrastructure;

namespace OnlineShop.Applicaition
{
    public interface IProductService
    {
        Task<List<ProductDto>> Getall();
        Task<ProductDto> Get(int id);
        Task<ProductDto> Add(ProductDto model);
    }
}