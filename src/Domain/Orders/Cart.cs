using Domain.Common;
using Domain.Products;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Orders
{
    public class Cart
    {
        private readonly List<CartLine> _lines = new();

        public IReadOnlyList<CartLine> Lines => _lines.AsReadOnly();
        public Money Total => _lines.Sum(x => x.Item.Total);

        public CartLine AddItem(CartItem item)
        {
            var existingLine = _lines.SingleOrDefault(x => x.Item.Equals(item));
            if (existingLine is not null)
            {
                existingLine.IncreaseQuantity(item.Quantity);
                return existingLine;
            }
            else
            {
                CartLine line = new (item);
                _lines.Add(line);
                return line;
            }
        }

        public void RemoveLine(Product product)
        {
            CartLine line = _lines.SingleOrDefault(l => l.Item.Product.Equals(product));
            if (line != null)
                _lines.Remove(line);
        }

        public void Clear()
        {
            _lines.Clear();
        }

    }
}
