using DiscountCalculator.Application.Model;

namespace DiscountCalculator.Application.Promotion
{
    public abstract class BasePromotionCalculator
    {
        protected BasePromotionCalculator(ShoppingCart cart)
        {
            ShoppingCart = cart;
        }

        protected ShoppingCart ShoppingCart { get; }

        public abstract string SKU { get; set; }

        public abstract decimal Amount { get; set; }

        public abstract int Quantity { get; set; }
        
        public abstract decimal CalculatePromotion();
    }
}