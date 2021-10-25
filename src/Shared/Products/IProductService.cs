using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shared.Products
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto.Index>> GetIndexAsync();
        Task<ProductDto.Detail> GetDetailAsync(int id);
        Task DeleteAsync(int id);
    }
}
