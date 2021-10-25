using Ardalis.GuardClauses;
using Domain.Common;
using Domain.Products;
using System.Collections.Generic;

namespace Domain.Orders
{
    public class CartItem : ValueObject
    {
        public Product Product { get; }
        public int Quantity { get; }
        public Money Total => Product.Price * Quantity;

        public CartItem(Product product, int quantity)
        {
            Product = Guard.Against.Null(product, nameof(product));
            Quantity = Guard.Against.Negative(quantity, nameof(quantity));
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Product;
        }
    }
}
