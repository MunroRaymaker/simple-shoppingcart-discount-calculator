namespace DiscountCalculator.Console.Model
{
    public interface IShoppingCart
    {
        void AddItemToCart(Product product);
        decimal GetCartTotal();
    }
}