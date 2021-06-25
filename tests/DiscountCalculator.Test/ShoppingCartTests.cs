using DiscountCalculator.Application.Model;
using DiscountCalculator.Application.Persistence;
using System.Linq;
using Xunit;

namespace DiscountCalculator.Test
{
    public class ShoppingCartTests
    {      

        [Fact]
        public void when_cart_has_no_products_should_return_0()
        {
            // Arrange 
            var shoppingCart = new ShoppingCart();
            shoppingCart.AddItem(new Product());

            // Act
            var actual = shoppingCart.GetCartTotal() - shoppingCart.GetPromotionsTotal();
            decimal expected = 0;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void when_cart_has_discount_products_should_return_discounted_total()
        {
            // Arrange 
            var shoppingCart = new ShoppingCart();
            shoppingCart.AddItem(ApplicationDatabase.Instance().Products.Single(p => p.SKU == "A"));
            shoppingCart.AddItem(ApplicationDatabase.Instance().Products.Single(p => p.SKU == "A"));
            shoppingCart.AddItem(ApplicationDatabase.Instance().Products.Single(p => p.SKU == "A"));

            // Act
            var actual = shoppingCart.GetCartTotal() - shoppingCart.GetPromotionsTotal();
            decimal expected = 130;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void when_cart_has_two_discount_products_should_return_discounted_total()
        {
            // Arrange 
            var shoppingCart = new ShoppingCart();
            shoppingCart.AddItem(ApplicationDatabase.Instance().Products.Single(p => p.SKU == "B"));
            shoppingCart.AddItem(ApplicationDatabase.Instance().Products.Single(p => p.SKU == "B"));

            // Act
            var actual = shoppingCart.GetCartTotal() - shoppingCart.GetPromotionsTotal();
            decimal expected = 45;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void when_cart_has_product_combo_should_return_discounted_total()
        {
            // Arrange 
            var shoppingCart = new ShoppingCart();
            shoppingCart.AddItem(ApplicationDatabase.Instance().Products.Single(p => p.SKU == "C"));
            shoppingCart.AddItem(ApplicationDatabase.Instance().Products.Single(p => p.SKU == "D"));

            // Act
            var actual = shoppingCart.GetCartTotal() - shoppingCart.GetPromotionsTotal();
            decimal expected = 30;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void when_cart_has_percentage_discount_returns_deducted_total()
        {
            // Arrange 
            var shoppingCart = new ShoppingCart();
            shoppingCart.AddItem(ApplicationDatabase.Instance().Products.Single(p => p.SKU == "E"));
            
            // Act
            var actual = shoppingCart.GetCartTotal() - shoppingCart.GetPromotionsTotal();
            decimal expected = 16;

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
        [InlineData("ABCDE", 126)]
        public void when_cart_has_items_should_calculate_discount(string productIds, decimal expected)
        {
            // Arrange 
            var shoppingCart = new ShoppingCart();

            foreach (var sku in productIds)
            {
                shoppingCart.AddItem(ApplicationDatabase.Instance().Products.Single(p => p.SKU == sku.ToString()));
            }

            // Act
            var actual = shoppingCart.GetCartTotal() - shoppingCart.GetPromotionsTotal();

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
