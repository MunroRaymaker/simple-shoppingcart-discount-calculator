using System;
using DiscountCalculator.Console;
using DiscountCalculator.Console.Model;
using Xunit;

namespace DiscountCalculator.Test
{
    public class ShoppingCartTests
    {
        [Fact]
        public void when_cart_has_products_should_return_total()
        {
            // Arrange 
            var shoppingCart = new ShoppingCart();
            shoppingCart.AddItemToCart(new Product());

            // Act
            var actual = shoppingCart.GetCartTotal();
            decimal expected = 100;

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
