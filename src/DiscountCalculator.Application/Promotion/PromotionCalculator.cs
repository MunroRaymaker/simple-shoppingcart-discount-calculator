using System.Collections.Generic;

namespace DiscountCalculator.Application.Promotion
{
    public class PromotionCalculator
    {
        private readonly IEnumerable<BasePromotionCalculator> promotionCalculators;

        public PromotionCalculator(IEnumerable<BasePromotionCalculator> basePromotions)
        {
            this.promotionCalculators = basePromotions;
        }

        public decimal CalculateTotalPromotions()
        {
            var totalPromotions = 0m;
            foreach (var item in this.promotionCalculators)
            {
                totalPromotions += item.CalculatePromotion();
            }
            return totalPromotions;
        }
    }
}
