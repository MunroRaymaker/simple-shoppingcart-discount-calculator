using System;
using System.Linq;
using DiscountCalculator.Application.Model;

namespace DiscountCalculator.Application.Promotion
{
    public class PercentageDiscountCalculator : BasePromotionCalculator
    {
        public override decimal CalculatePromotion(ShoppingCart cart)
        {
            var discount = Math.Round(cart.GetCartItems()
                    .Where(i => i.SKU == SKU)
                    .Sum(i => i.UnitPrice * Amount)
                , 2);

            return discount;
        }
    }
}