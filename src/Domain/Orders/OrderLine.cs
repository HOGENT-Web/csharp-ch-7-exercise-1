using Ardalis.GuardClauses;
using Domain.Common;

namespace Domain.Orders
{
    public class OrderLine : Entity
    {
        public OrderItem Item { get; }
        public OrderLine(OrderItem item)
        {
            Item = Guard.Against.Null(item,nameof(OrderItem));
        }
    }
}