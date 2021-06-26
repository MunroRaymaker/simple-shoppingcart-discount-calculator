using DiscountCalculator.Application.Model;
using DiscountCalculator.Application.Persistence;
using DiscountCalculator.Application.Promotion;
using System.Diagnostics;

namespace DiscountCalculator.Console
{
    /*             
       Promotion engine
       buy n items for fixed price 
       buy two different SKUs for fixed price
       
       Active promotions
       3 x A = 130
       2 x B = 45
       C + D = 30
       
       Normal price
       A 50
       B 30
       C 20
       D 15             
    */
    internal class Program
    {
        private static readonly ApplicationDatabase db = ApplicationDatabase.Instance();

        private static void Main(string[] args)
        {
            System.Console.WriteLine("***************************");
            System.Console.WriteLine("Simple Discount Calculator.");
            System.Console.WriteLine("***************************");

            var cart = new ShoppingCart();

            cart.AddItem(db.GetProductBySku("A"));
            cart.AddItem(db.GetProductBySku("A"));
            cart.AddItem(db.GetProductBySku("A"));
            cart.AddItem(db.GetProductBySku("B"));
            cart.AddItem(db.GetProductBySku("B"));
            cart.AddItem(db.GetProductBySku("C"));
            cart.AddItem(db.GetProductBySku("D"));

            var subtotal = cart.GetCartTotal();

            foreach (var cartItem in cart.GetCartItems())
            {
                System.Console.WriteLine($"{cartItem.SKU} | {cartItem.Name.PadRight(10)} | Price: {cartItem.UnitPrice} ");
            }
            
            var calculator = new PromotionCalculator(cart);
            var discountTotal = calculator.CalculateTotalPromotions();

            System.Console.WriteLine($"==========================================");
            System.Console.WriteLine($"Cart subtotal: {subtotal:F2}.");
            System.Console.WriteLine($"Cart discount subtotal: {discountTotal:F2}.");
            System.Console.WriteLine($"Cart with id '{cart.ShoppingCartId}' has discounted total of {subtotal - discountTotal:F2}.");

            if (Debugger.IsAttached)
            {
                System.Console.WriteLine("Press any key...");
                System.Console.ReadKey();
            }
        }
    }
}
