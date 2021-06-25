using System.Collections.Generic;

namespace DiscountCalculator.Application.Promotion
{
    public class PromotionCalculator
    {
        private readonly IEnumerable<BasePromotionCalculator> _promotionCalculators;

        public PromotionCalculator(IEnumerable<BasePromotionCalculator> basePromotions)
        {
            _promotionCalculators = basePromotions;
        }

        public decimal CalculateTotalPromotions()
        {
            var totalPromotions = 0m;
            foreach (var item in this._promotionCalculators)
            {
                totalPromotions += item.CalculatePromotion();
            }
            return totalPromotions;
        }
    }
}
