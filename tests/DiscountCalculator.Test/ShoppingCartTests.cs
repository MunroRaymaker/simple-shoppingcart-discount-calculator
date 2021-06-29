using DiscountCalculator.Application.Model;
using DiscountCalculator.Application.Promotion;
using Xunit;

namespace DiscountCalculator.Test
{
    public class ShoppingCartTests
    {
        private readonly ProductRepository db = ProductRepository.Instance();

        [Fact]
        public void when_cart_has_no_products_should_return_0()
        {
            // Arrange 
            var shoppingCart = new ShoppingCart();
            shoppingCart.AddItem(new Product());
            var calculator = new PromotionCalculator(shoppingCart);

            // Act
            var actual = shoppingCart.GetCartTotal() - calculator.CalculateTotalPromotions();
            decimal expected = 0;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void when_cart_has_discount_products_should_return_discounted_total()
        {
            // Arrange 
            var shoppingCart = new ShoppingCart();
            shoppingCart.AddItem(db.GetProductBySku("A"));
            shoppingCart.AddItem(db.GetProductBySku("A"));
            shoppingCart.AddItem(db.GetProductBySku("A"));
            var calculator = new PromotionCalculator(shoppingCart);

            // Act
            var actual = shoppingCart.GetCartTotal() - calculator.CalculateTotalPromotions();
            decimal expected = 130;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void when_cart_has_two_discount_products_should_return_discounted_total()
        {
            // Arrange 
            var shoppingCart = new ShoppingCart();
            shoppingCart.AddItem(db.GetProductBySku("B"));
            shoppingCart.AddItem(db.GetProductBySku("B"));
            var calculator = new PromotionCalculator(shoppingCart);

            // Act
            var actual = shoppingCart.GetCartTotal() - calculator.CalculateTotalPromotions();
            decimal expected = 45;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void when_cart_has_product_combo_should_return_discounted_total()
        {
            // Arrange 
            var shoppingCart = new ShoppingCart();
            shoppingCart.AddItem(db.GetProductBySku("C"));
            shoppingCart.AddItem(db.GetProductBySku("D"));
            var calculator = new PromotionCalculator(shoppingCart);

            // Act
            var actual = shoppingCart.GetCartTotal() - calculator.CalculateTotalPromotions();
            decimal expected = 30;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void when_cart_has_percentage_discount_returns_deducted_total()
        {
            // Arrange 
            var shoppingCart = new ShoppingCart();
            shoppingCart.AddItem(db.GetProductBySku("E"));
            var calculator = new PromotionCalculator(shoppingCart);

            // Act
            var actual = shoppingCart.GetCartTotal() - calculator.CalculateTotalPromotions();
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
                shoppingCart.AddItem(db.GetProductBySku(sku.ToString()));
            }
            var calculator = new PromotionCalculator(shoppingCart);

            // Act
            var actual = shoppingCart.GetCartTotal() - calculator.CalculateTotalPromotions();

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
