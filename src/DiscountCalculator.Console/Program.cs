using DiscountCalculator.Application.Model;
using DiscountCalculator.Application.Persistence;
using DiscountCalculator.Application.Promotion;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace DiscountCalculator.Console
{
    internal class Program
    {
        private static ApplicationDatabase db = ApplicationDatabase.Instance();

        private static void Main(string[] args)
        {
            System.Console.WriteLine("***************************");
            System.Console.WriteLine("Simple Discount Calculator.");
            System.Console.WriteLine("***************************");

            var cart = ShoppingCart.GetCart();

            // Add 3 A's to cart
            var item = db.Products.Single(p => p.SKU == "A");
            cart.AddItem(item);
            cart.AddItem(item);
            cart.AddItem(item);

            // Add 2 B's to cart
            item = db.Products.Single(p => p.SKU == "B");
            cart.AddItem(item);
            cart.AddItem(item);

            // Add 1 C's to cart
            item = db.Products.Single(p => p.SKU == "C");
            cart.AddItem(item);

            // Add 1 D's to cart
            item = db.Products.Single(p => p.SKU == "D");
            cart.AddItem(item);

            // Get Cart total
            var subtotal = cart.GetCartTotal();
            
            foreach (var cartItem in cart.GetCartItems())
            {
                System.Console.WriteLine($"{cartItem.SKU} | {cartItem.Name.PadRight(10)} | Price: {cartItem.UnitPrice} ");
            }



            /*             
             * Discount
             * buy n items for fixed price 
             * buy two different SKUs for fixed price
             *
             * active promotions
             * 3 x A = 130
             * 2 x B = 45
             * C + D = 30
             *
             * normal price
             * A 50
             * B 30
             * C 20
             * D 15             
             */

            // Calculate discounts
            // Adds discounts by "reversing" the logic. Eg. a fixed price of 130 for three A's would equal a deduction of 20 for 3.
            var discounts = new List<BasePromotionCalculator>
            {                
                new FixedPriceForTwoSkusDiscountCalculator(cart){ SKU = "CD", Amount = 5, Quantity = 1},
                new FixedPriceForNDiscountCalculator(cart){ SKU = "A", Amount = 20, Quantity = 3},
                new FixedPriceForNDiscountCalculator(cart){ SKU = "B", Amount = 15, Quantity = 2},
                new PercentageDiscountCalculator(cart) { SKU = "E", Amount = 0.2m, Quantity = 1}
            };

            var calculator = new PromotionCalculator(discounts);
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
