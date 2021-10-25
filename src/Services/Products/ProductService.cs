using Domain.Products;
using Shared.Products;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Products
{
    public class ProductService : IProductService
    {
        private static readonly List<ProductDto.Detail> products = new();
        static ProductService()
        {
            var fakeProducts = new ProductFaker().Generate(25).Select(x => new ProductDto.Detail
            {
                Id = x.Id,
                Name = x.Name,
                InStock = x.InStock,
                Price = x.Price,
                Category = x.Category.Name,
                Description = x.Description,
            });
            products.AddRange(fakeProducts);
        }

        public async Task<IEnumerable<ProductDto.Index>> GetIndexAsync()
        {
            await Task.Delay(100);
            return products.Select(x => new ProductDto.Index
            {
                Id = x.Id,
                InStock = x.InStock,
                Name = x.Name,  
                Price = x.Price,
            });
        }

        public async Task<ProductDto.Detail> GetDetailAsync(int id)
        {
            await Task.Delay(100);
            return products.SingleOrDefault(x => x.Id == id);
        }

        public async Task DeleteAsync(int id)
        {
            await Task.Delay(100);
            var p = products.SingleOrDefault(x => x.Id == id);
            products.Remove(p);
        }
    }
}
