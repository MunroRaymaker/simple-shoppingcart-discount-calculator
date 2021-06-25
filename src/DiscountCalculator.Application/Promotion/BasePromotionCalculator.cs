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

        public string SKU { get; set; }

        public decimal Amount { get; set; }

        public int Quantity { get; set; }
        
        public abstract decimal CalculatePromotion();
    }
}