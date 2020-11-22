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
            var shoppingCart = ShoppingCart.GetCart();
            shoppingCart.AddItem(new Product());

            // Act
            var actual = shoppingCart.GetCartTotal();
            decimal expected = 100;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void when_cart_has_discount_products_should_return_discounted_total()
        {
            // Arrange 
            var shoppingCart = ShoppingCart.GetCart();
            shoppingCart.AddItem(new Product { Name = "Apple", SKU = "A", UnitPrice = 50 });
            shoppingCart.AddItem(new Product { Name = "Apple", SKU = "A", UnitPrice = 50 });
            shoppingCart.AddItem(new Product { Name = "Apple", SKU = "A", UnitPrice = 50 });

            // Act
            var actual = shoppingCart.GetCartTotal();
            decimal expected = 130;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void when_cart_has_two_discount_products_should_return_discounted_total()
        {
            // Arrange 
            var shoppingCart = ShoppingCart.GetCart();
            shoppingCart.AddItem(new Product { Name = "Banana", SKU = "B", UnitPrice = 30 });
            shoppingCart.AddItem(new Product { Name = "Banana", SKU = "B", UnitPrice = 30 });

            // Act
            var actual = shoppingCart.GetCartTotal();
            decimal expected = 45;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void when_cart_has_product_combo_should_return_discounted_total()
        {
            // Arrange 
            var shoppingCart = ShoppingCart.GetCart();
            shoppingCart.AddItem(new Product { Name = "Carrot", SKU = "C", UnitPrice = 20 });
            shoppingCart.AddItem(new Product { Name = "Dates", SKU = "D", UnitPrice = 15 });

            // Act
            var actual = shoppingCart.GetCartTotal();
            decimal expected = 30;

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
