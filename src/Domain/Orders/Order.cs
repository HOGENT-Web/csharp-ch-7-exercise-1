using Ardalis.GuardClauses;
using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Orders
{
    public class Order : Entity
    {
        private readonly List<OrderLine> _lines = new();

        public DateTime OrderDate { get; }
        public DeliveryDate DeliveryDate { get; }
        public bool HasGiftWrapping { get; }
        public Address ShippingAddress { get; }
        public IReadOnlyList<OrderLine> Items => _lines.AsReadOnly();

        public Money Total => Items.Sum(line => line.Item.Price * line.Item.Quantity);

        public Order(Cart cart, DeliveryDate deliveryDate, bool hasGiftWrapping, Address shippingAddress)
        {
            ShippingAddress = Guard.Against.Null(shippingAddress,nameof(shippingAddress));
            Guard.Against.Null(cart,nameof(cart));
            Guard.Against.Zero(cart.Lines.Count, $"{nameof(Cart)} {nameof(Cart.Lines)}");
            OrderDate = DateTime.UtcNow;
            DeliveryDate = deliveryDate;
            HasGiftWrapping = hasGiftWrapping;
            
            foreach (var line in cart.Lines)
            {
                _lines.Add(new OrderLine(new OrderItem(line.Item.Product, line.Item.Quantity)));
            }

            cart.Clear();

        }
    }
}