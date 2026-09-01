using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using ProductCachingPractice.Data;
using ProductCachingPractice.DTOs;

namespace ProductCachingPractice.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;
        private readonly IMemoryCache _memoryCache;
        private readonly ILogger<ProductService> _logger;
        public ProductService(AppDbContext context, IMemoryCache memoryCache, ILogger<ProductService> logger)
        {
            _context = context;
            _memoryCache = memoryCache;
            _logger = logger;
        }

        public async Task<ProductGetDto?> GetProductByIdAsync(int id)
        {
            var CacheKey = $"Product_{id}";

            if(_memoryCache.TryGetValue(CacheKey, out ProductGetDto? cachedProduct))
            {
                _logger.LogInformation(
                "Cache HIT for product {ProductId}",
                id);

                return cachedProduct;
            }

            _logger.LogInformation(
            "Cache MISS for product {ProductId}",
            id);

            var product = await _context.Products
            .FirstOrDefaultAsync(p => p.Id == id);
            if (product == null)
                return null;

            var productDto =  new ProductGetDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock,
                UpdatedAt = product.UpdatedAt
            };

            _memoryCache.Set(CacheKey, productDto, TimeSpan.FromMinutes(5));
            return productDto;
        }
    }
}
