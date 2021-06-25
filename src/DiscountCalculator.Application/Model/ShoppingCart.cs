using DiscountCalculator.Application.Promotion;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DiscountCalculator.Application.Model
{
    public class ShoppingCart : IShoppingCart
    {
        private readonly List<Product> items = new List<Product>();
        private readonly PromotionCalculator calculator;

        public string ShoppingCartId { get; private set; }

        public ShoppingCart()
        {
            ShoppingCartId = GetCartId();

            // Calculate discounts
            // Adds discounts by "reversing" the logic. Eg. a fixed price of 130 for three A's would equal a deduction of 20 for 3.
            // TODO Move out of shoppingcart because it violates the single responsibility principle.
            var promotions = new List<BasePromotionCalculator>
            {
                new FixedPriceForTwoSkusDiscountCalculator(this){ SKU = "CD", Amount = 5, Quantity = 1},
                new FixedPriceForNDiscountCalculator(this){ SKU = "A", Amount = 20, Quantity = 3},
                new FixedPriceForNDiscountCalculator(this){ SKU = "B", Amount = 15, Quantity = 2},
                new PercentageDiscountCalculator(this) { SKU = "E", Amount = 0.2m, Quantity = 1}
            };

            calculator = new PromotionCalculator(promotions);
        }

        public void AddItem(Product product)
        {
            items.Add(product);
        }

        public IList<Product> GetCartItems()
        {
            return items;
        }

        public decimal GetCartTotal()
        {
            var subtotal = items.Sum(p => p.UnitPrice);

            if (!items.Any())
            {
                return 0;
            }

            return subtotal;
        }

        public decimal GetPromotionsTotal()
        {
            return calculator.CalculateTotalPromotions();
        }

        private string GetCartId()
        {
            return Guid.NewGuid().ToString();
        }
    }
}