using System;
using System.Collections.Generic;
using System.Linq;
using DiscountCalculator.Console.Persistence;

namespace DiscountCalculator.Console.Model
{
    public class ShoppingCart : IShoppingCart
    {
        private readonly ApplicationDatabase db = ApplicationDatabase.Instance();

        private readonly List<Product> items = new List<Product>();
        
        public string ShoppingCartId { get; private set; }

        public static ShoppingCart GetCart()
        {
            var cart = new ShoppingCart();
            cart.ShoppingCartId = cart.GetCartId();
            return cart;
        }

        public void AddItem(Product product)
        {
            this.items.Add(product);
        }

        public decimal GetCartTotal()
        {
            return this.items.Sum(p => p.UnitPrice);
        }

        private string GetCartId()
        {
            return Guid.NewGuid().ToString();
        }
    }
}