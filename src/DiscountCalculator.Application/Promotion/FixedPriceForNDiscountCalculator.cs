using System.Linq;
using DiscountCalculator.Application.Model;

namespace DiscountCalculator.Application.Promotion
{
    public class FixedPriceForNDiscountCalculator : BasePromotionCalculator
    {
        public override decimal CalculatePromotion(ShoppingCart cart)
        {
            var eligibleItemsCount = cart.GetCartItems().Count(product => product.SKU == SKU);
            var discountTotal = eligibleItemsCount / Quantity * Amount;

            return discountTotal;
        }
    }
}