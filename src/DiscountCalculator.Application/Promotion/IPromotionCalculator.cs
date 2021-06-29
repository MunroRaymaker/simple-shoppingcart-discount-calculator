using DiscountCalculator.Application.Model;
using System.Collections.Generic;

namespace DiscountCalculator.Application.Promotion
{
    public interface IPromotionCalculator
    {
        decimal CalculateTotalPromotions(IReadOnlyList<Product> items);
    }
}