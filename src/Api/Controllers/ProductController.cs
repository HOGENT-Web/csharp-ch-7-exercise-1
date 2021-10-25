using Microsoft.AspNetCore.Mvc;
using Shared.Products;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        public Task<IEnumerable<ProductDto.Index>> GetIndexAsync()
        {
            return productService.GetIndexAsync();
        }

        [HttpGet("id")]
        public Task<ProductDto.Detail> GetDetailAsync(int id)
        {
            return productService.GetDetailAsync(id);
        }

        [HttpDelete("id")]
        public Task DeleteAsync(int id)
        {
            return productService.DeleteAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateAsync(ProductDto.Create model)
        {
            var id  = await productService.CreateAsync(model);
            return CreatedAtAction("GetDetail", id);
        }
    }
}
