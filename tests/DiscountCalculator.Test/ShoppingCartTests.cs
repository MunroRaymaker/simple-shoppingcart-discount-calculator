using System.Linq;
using DiscountCalculator.Console.Model;
using DiscountCalculator.Console.Persistence;
using Xunit;

namespace DiscountCalculator.Test
{
    public class ShoppingCartTests
    {
        [Fact]
        public void when_cart_has_no_products_should_return_0()
        {
            // Arrange 
            var shoppingCart = ShoppingCart.GetCart();
            shoppingCart.AddItem(new Product());

            // Act
            var actual = shoppingCart.GetCartTotal();
            decimal expected = 0;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void when_cart_has_discount_products_should_return_discounted_total()
        {
            // Arrange 
            var shoppingCart = ShoppingCart.GetCart();
            shoppingCart.AddItem(ApplicationDatabase.Instance().Products.Single(p => p.SKU == "A"));
            shoppingCart.AddItem(ApplicationDatabase.Instance().Products.Single(p => p.SKU == "A"));
            shoppingCart.AddItem(ApplicationDatabase.Instance().Products.Single(p => p.SKU == "A"));

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
            shoppingCart.AddItem(ApplicationDatabase.Instance().Products.Single(p => p.SKU == "B"));
            shoppingCart.AddItem(ApplicationDatabase.Instance().Products.Single(p => p.SKU == "B"));

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
            shoppingCart.AddItem(ApplicationDatabase.Instance().Products.Single(p => p.SKU == "C"));
            shoppingCart.AddItem(ApplicationDatabase.Instance().Products.Single(p => p.SKU == "D"));

            // Act
            var actual = shoppingCart.GetCartTotal();
            decimal expected = 30;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("AAA", 130)]
        [InlineData("BB", 45)]
        [InlineData("CCCDDD", 90)]
        [InlineData("CD", 30)]
        [InlineData("ABC", 100)]
        [InlineData("AAAAABBBBBC", 370)]
        [InlineData("AAABBBBBCD", 280)]
        public void when_cart_has_items_should_calculate_discount(string productIds, decimal expected)
        {
            // Arrange 
            var shoppingCart = ShoppingCart.GetCart();

            foreach (var sku in productIds)
            {
                shoppingCart.AddItem(ApplicationDatabase.Instance().Products.Single(p => p.SKU == sku.ToString()));
            }
            
            // Act
            var actual = shoppingCart.GetCartTotal();

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
