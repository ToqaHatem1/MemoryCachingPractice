using ProductCachingPractice.DTOs;

namespace ProductCachingPractice.Services
{
    public interface IProductService
    {
        Task<ProductGetDto> GetProductByIdAsync(int id);
    }
}
