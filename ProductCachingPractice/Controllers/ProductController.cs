using Microsoft.AspNetCore.Mvc;
using ProductCachingPractice.Services;

namespace ProductCachingPractice.Controllers
{
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        //[HttpPost]
        //public async Task<IActionResult> CreateProduct([FromBody] CreateProductDto product)
        //{
        //    _context.Products.Add(new Product
        //    {
        //        Name = product.Name,
        //        Price = product.Price,
        //        Stock = product.Stock
        //    });
        //    await _context.SaveChangesAsync();
        //    return Ok(product);
        //}

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);

            if (product == null)
                return NotFound();

            return Ok(product);
        }
    }
}
