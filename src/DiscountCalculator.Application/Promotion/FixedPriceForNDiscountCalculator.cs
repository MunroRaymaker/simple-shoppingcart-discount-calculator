using DiscountCalculator.Application.Model;
using System.Linq;

namespace DiscountCalculator.Application.Promotion
{
    public class FixedPriceForNDiscountCalculator : BasePromotionCalculator
    {
        public FixedPriceForNDiscountCalculator(ShoppingCart cart) : base(cart) { }

        public override string SKU { get; set; }
        public override decimal Amount { get; set; }
        public override int Quantity { get; set; }

        public override decimal CalculatePromotion()
        {
            int eligibleItemsCount = this.ShoppingCart.GetCartItems().Count(product => product.SKU == SKU);
            var discountTotal = eligibleItemsCount / Quantity * Amount;

            return discountTotal;
        }
    }
}