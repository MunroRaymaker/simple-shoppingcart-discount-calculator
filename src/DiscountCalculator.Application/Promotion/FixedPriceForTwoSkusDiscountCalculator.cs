using System.Collections.Generic;
using System.Linq;
using DiscountCalculator.Application.Model;

namespace DiscountCalculator.Application.Promotion
{
    public class FixedPriceForTwoSkusDiscountCalculator : BasePromotionCalculator
    {
        public override decimal CalculatePromotion(IReadOnlyList<Product> items)
        {
            // We assume this discount has two sku's, eg. CD.
            // Zip applies a specified function to the corresponding elements of two sequences, producing a sequence of the results.
            var pairs = items
                .Where(i => i.SKU == SKU[0].ToString())
                .Zip(
                    items.Where(i => i.SKU == SKU[1].ToString()),
                    (l, r) => new {Left = l, Right = r}).Count();

            var discountTotal = pairs * Amount;
            return discountTotal;
        }
    }
}