using Ardalis.GuardClauses;

namespace Domain.Orders
{
    public class CartLine
    {
        public CartItem Item { get; private set; }
        public CartLine(CartItem item)
        {
            Guard.Against.Null(item, nameof(CartItem));
            Item = item;
        }

        public void IncreaseQuantity(int quantity)
        {
            Item = new CartItem(Item.Product, Item.Quantity + quantity);
        }
    }
}
