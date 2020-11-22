namespace DiscountCalculator.Console.Model
{
    public interface IShoppingCart
    {
        void AddItem(Product product);
        decimal GetCartTotal();
    }
}