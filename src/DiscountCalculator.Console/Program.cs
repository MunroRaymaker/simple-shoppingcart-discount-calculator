namespace DiscountCalculator.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("***************************");
            System.Console.WriteLine("Simple Discount Calculator.");
            System.Console.WriteLine("***************************");
        }
    }

    public class Product
    {
        public string SKU { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
    }
    
    public interface IShoppingCart
    {
        void AddItemToCart(Product product);
        decimal GetCartTotal();
    }

    public class ShoppingCart : IShoppingCart
    {
        public void AddItemToCart(Product product)
        {
        }

        public decimal GetCartTotal()
        {
            return 100;
        }
    }
}
