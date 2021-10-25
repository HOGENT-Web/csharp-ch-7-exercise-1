using Domain.Customers;
using Domain.Orders;
using Domain.Products;
using Shouldly;
using System;
using System.Linq;
using Xunit;

namespace Domain.Tests.Customers
{
    public class Customer_Should
    {
        [Fact]
        public void Be_Able_To_Place_Order_With_2_Different_Products()
        {
            var products = new ProductFaker().Generate(2);
            Customer customer = new CustomerFaker();
            Cart cart = new();
            cart.AddItem(new CartItem(products[0], 1));
            cart.AddItem(new CartItem(products[1], 1));
            DeliveryDate deliveryDate = new(DateTime.UtcNow.AddDays(2));

            customer.PlaceOrder(cart, deliveryDate, true, customer.Address);

            customer.Orders.Count.ShouldBe(1);
            var order = customer.Orders.First();
            order.DeliveryDate.ShouldBe(deliveryDate);
            order.ShippingAddress.ShouldBe(customer.Address);
            order.Items.Count.ShouldBe(2);
        }

        [Fact]
        public void Be_Able_To_Place_Order_With_One_Product_With_Correct_Quantity()
        {
            Product product = new ProductFaker();
            Customer customer = new CustomerFaker();
            Cart cart = new();
            cart.AddItem(new CartItem(product, 1));
            cart.AddItem(new CartItem(product, 1));
            DeliveryDate deliveryDate = new(DateTime.UtcNow.AddDays(2));

            customer.PlaceOrder(cart, deliveryDate, true, customer.Address);

            customer.Orders.Count.ShouldBe(1);
            var order = customer.Orders.First();
            order.DeliveryDate.ShouldBe(deliveryDate);
            order.ShippingAddress.ShouldBe(customer.Address);
            order.Items.Count.ShouldBe(1);
            var item = order.Items.First().Item;
            item.Product.ShouldBe(product);
            item.Quantity.ShouldBe(2);
            item.Price.ShouldBe(product.Price);
        }

        [Fact]
        public void Not_Be_Able_To_Order_When_Cart_Is_Empty()
        {
            Customer customer = new CustomerFaker();
            Cart cart = new();
            DeliveryDate deliveryDate = new(DateTime.UtcNow.AddDays(2));

            Should.Throw<Exception>(() =>
            {
                customer.PlaceOrder(cart, deliveryDate, true, customer.Address);
            });
        }
    }
}
