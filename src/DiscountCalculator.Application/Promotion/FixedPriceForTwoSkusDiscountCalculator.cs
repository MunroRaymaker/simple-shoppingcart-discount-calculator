using DiscountCalculator.Application.Model;
using System.Linq;

namespace DiscountCalculator.Application.Promotion
{
    public class FixedPriceForTwoSkusDiscountCalculator : BasePromotionCalculator
    {
        public FixedPriceForTwoSkusDiscountCalculator(ShoppingCart cart) : base(cart){ }
        
        public override decimal CalculatePromotion()
        {
            // We assume this discount has two sku's, eg. CD.
            // Zip applies a specified function to the corresponding elements of two sequences, producing a sequence of the results.
            var pairs = this.ShoppingCart.GetCartItems()
                .Where(i => i.SKU == SKU[0].ToString())
                .Zip(
                    this.ShoppingCart.GetCartItems().Where(i => i.SKU == SKU[1].ToString()),
                    (l, r) => new { Left = l, Right = r }).Count();

            var discountTotal = pairs * Amount;
            return discountTotal;
        }
    }
}