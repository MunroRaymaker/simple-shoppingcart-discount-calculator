using System;
using System.Collections.Generic;
using System.Linq;
using DiscountCalculator.Application.Persistence;

namespace DiscountCalculator.Application.Model
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

        public IList<Product> GetCartItems()
        {
            return this.items;
        }

        public decimal GetCartTotal()
        {
            var subtotal = this.items.Sum(p => p.UnitPrice);

            if (!this.items.Any()) return 0;
                        
            return subtotal;
        }

        private string GetCartId()
        {
            return Guid.NewGuid().ToString();
        }
    }
}