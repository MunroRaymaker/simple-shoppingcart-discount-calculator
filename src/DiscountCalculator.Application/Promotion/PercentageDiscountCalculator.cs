using System;
using System.Linq;
using DiscountCalculator.Application.Model;

namespace DiscountCalculator.Application.Promotion
{
    public class PercentageDiscountCalculator : BasePromotionCalculator
    {
        public PercentageDiscountCalculator(ShoppingCart cart) : base(cart) { }

        public override string SKU { get; set; }
        public override decimal Amount { get; set; }
        public override int Quantity { get; set; }

        public override decimal CalculatePromotion()
        {
            var discount = Math.Round(this.ShoppingCart.GetCartItems()
                    .Where(i => i.SKU == SKU)
                    .Sum(i => i.UnitPrice * Amount)
                    , 2);

            return discount;
        }
    }
}