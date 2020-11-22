using System.Collections.Generic;

namespace DiscountCalculator.Console.Model
{
    public interface IShoppingCart
    {
        void AddItem(Product product);
        IList<Product> GetCartItems();
        decimal GetCartTotal();
    }
}