using DiscountCalculator.Application.Model;

namespace DiscountCalculator.Application.Promotion
{
    public interface IPromotionCalculator
    {
        decimal CalculateTotalPromotions(ShoppingCart cart);
    }
}