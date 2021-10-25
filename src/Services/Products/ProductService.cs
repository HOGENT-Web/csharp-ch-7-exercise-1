using Domain.Common;
using Domain.Products;
using Shared.Products;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Services.Products
{
    public class ProductService : IProductService
    {
        private static readonly List<ProductDto.Detail> products = new();
        static ProductService()
        {
            var fakeProducts = new ProductFaker().Generate(10).Select(x => new ProductDto.Detail
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

        public async Task<int> CreateAsync(ProductDto.Create model)
        {
            await Task.Delay(100);
            var price = new Money(model.Price);
            var category = new Category(model.Category);
            var p = new Product(model.Name, model.Description, price, model.InStock, category);

            // Since we made the Id protected we cannot set it, normally the Database takes care of this.
            // It's a small hack to "generate" a fake id.
            // If you want to set the id even if it's private you can use the following code (but that's some hacky stuff)
            // p.GetType().GetField("id", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(p, products.Max(x => x.Id) +1);

            var mappedProduct = new ProductDto.Detail 
            { 
                Id = products.Max(x => x.Id) +1, // fake id
                Category = p.Name,
                Description = p.Description,
                InStock = p.InStock,
                Name = p.Name,
                Price = price,
            };

            products.Add(mappedProduct);
            return mappedProduct.Id;
        }
    }
}
