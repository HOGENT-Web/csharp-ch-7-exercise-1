using Ardalis.GuardClauses;
using Domain.Common;
using Domain.Products;
using System.Collections.Generic;

namespace Domain.Orders
{
    public class OrderItem : ValueObject
    {
        public Product Product { get; }
        public int Quantity { get; }
        public Money Price { get; }

        public OrderItem(Product product, int quantity )
        {
            Product = Guard.Against.Null(product,nameof(product));
            Quantity = Guard.Against.Negative(quantity,nameof(quantity));
            Price = Product.Price;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Product;
            yield return Quantity;
            yield return Price;
        }
    }
}