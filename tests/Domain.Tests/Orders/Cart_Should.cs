using Domain.Orders;
using Domain.Products;
using Shouldly;
using System.Linq;
using Xunit;

namespace Domain.Tests.Orders
{
    public class Cart_Should
    {
        [Fact]
        public void Add_Line_When_Not_Already_Present_Product()
        {
            var cart = new Cart();
            var product = new ProductFaker();
            var item = new CartItem(product, 5);
            cart.AddItem(item);

            cart.Lines.Count.ShouldBe(1);
            cart.Lines.FirstOrDefault().Item.Quantity.ShouldBe(5);
        }
        [Fact]
        public void Increase_Quanity_To_Line_When_Already_Present_Product()
        {
            var cart = new Cart();
            var product = new ProductFaker();
            var item = new CartItem(product, 1);
            cart.AddItem(item);

            cart.AddItem(item);

            cart.Lines.Count.ShouldBe(1);
            cart.Lines.FirstOrDefault().Item.Quantity.ShouldBe(2);
        }
    }
}
