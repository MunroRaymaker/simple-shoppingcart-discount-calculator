using System.Collections.Generic;

namespace DiscountCalculator.Application.Model
{
    public interface IShoppingCart
    {
        void AddItem(Product product);
        IList<Product> GetCartItems();
        decimal GetCartSubTotal();
    }
}