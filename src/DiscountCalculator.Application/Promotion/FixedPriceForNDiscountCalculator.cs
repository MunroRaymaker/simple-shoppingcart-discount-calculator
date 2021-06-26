using System.Linq;
using DiscountCalculator.Application.Model;

namespace DiscountCalculator.Application.Promotion
{
    public class FixedPriceForNDiscountCalculator : BasePromotionCalculator
    {
        public FixedPriceForNDiscountCalculator(ShoppingCart cart) : base(cart) { }

        public override decimal CalculatePromotion()
        {
            var eligibleItemsCount = ShoppingCart.GetCartItems().Count(product => product.SKU == SKU);
            var discountTotal = eligibleItemsCount / Quantity * Amount;

            return discountTotal;
        }
    }
}