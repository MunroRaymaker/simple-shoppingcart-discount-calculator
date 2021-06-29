using DiscountCalculator.Application.Model;
using System.Collections.Generic;
using System.Linq;

namespace DiscountCalculator.Application.Promotion
{
    public class FixedPriceForNDiscountCalculator : BasePromotionCalculator
    {
        public override decimal CalculatePromotion(IReadOnlyList<Product> items)
        {
            var eligibleItemsCount = items.Count(product => product.SKU == SKU);
            var discountTotal = eligibleItemsCount / Quantity * Amount;

            return discountTotal;
        }
    }
}