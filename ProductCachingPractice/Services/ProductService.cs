using Microsoft.EntityFrameworkCore;
using ProductCachingPractice.Data;
using ProductCachingPractice.DTOs;

namespace ProductCachingPractice.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;
        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ProductGetDto> GetProductByIdAsync(int id)
        {
            var product = await _context.Products
            .FirstOrDefaultAsync(p => p.Id == id);
            if (product == null)
                return null;

            return new ProductGetDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock,
                UpdatedAt = product.UpdatedAt
            };
        }
    }
}
