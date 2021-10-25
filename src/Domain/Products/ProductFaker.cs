using Bogus;
using Domain.Common;

namespace Domain.Products
{
    public class ProductFaker : Faker<Product>
    {
        public ProductFaker()
        {
            CustomInstantiator(f => new Product(f.Commerce.ProductName(), f.Commerce.ProductDescription(), new Money(f.Random.Decimal(0, 200)), f.Random.Bool(), new CategoryFaker()));
            RuleFor(x => x.Id, f => f.Random.Int());
        }
    }
}
