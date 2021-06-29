using DiscountCalculator.Application.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DiscountCalculator.Application.Promotion
{
    public class PercentageDiscountCalculator : BasePromotionCalculator
    {
        public override decimal CalculatePromotion(IReadOnlyList<Product> items)
        {
            var discount = Math.Round(items
                    .Where(i => i.SKU == SKU)
                    .Sum(i => i.UnitPrice * Amount)
                , 2);

            return discount;
        }
    }
}