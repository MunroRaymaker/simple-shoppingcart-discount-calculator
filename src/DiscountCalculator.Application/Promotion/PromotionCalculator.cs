using System.Collections.Generic;
using DiscountCalculator.Application.Model;

namespace DiscountCalculator.Application.Promotion
{
    public class PromotionCalculator
    {
        private readonly IEnumerable<BasePromotionCalculator> promotionCalculators;

        public PromotionCalculator(ShoppingCart cart)
        {
            // Calculate discounts
            // Adds discounts by "reversing" the logic. Eg. a fixed price of 130 for three A's would equal a deduction of 20 for 3.
            var promotions = new List<BasePromotionCalculator>
            {
                new FixedPriceForTwoSkusDiscountCalculator(cart) {SKU = "CD", Amount = 5, Quantity = 1},
                new FixedPriceForNDiscountCalculator(cart) {SKU = "A", Amount = 20, Quantity = 3},
                new FixedPriceForNDiscountCalculator(cart) {SKU = "B", Amount = 15, Quantity = 2},
                new PercentageDiscountCalculator(cart) {SKU = "E", Amount = 0.2m, Quantity = 1}
            };
            
            this.promotionCalculators = promotions;
        }

        public decimal CalculateTotalPromotions()
        {
            var totalPromotions = 0m;
            foreach (var item in this.promotionCalculators) totalPromotions += item.CalculatePromotion();
            return totalPromotions;
        }
    }
}