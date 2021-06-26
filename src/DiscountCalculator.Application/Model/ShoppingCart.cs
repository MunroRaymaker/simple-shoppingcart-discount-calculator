using System;
using System.Collections.Generic;
using System.Linq;

namespace DiscountCalculator.Application.Model
{
    public class ShoppingCart : IShoppingCart
    {
        private readonly List<Product> items = new List<Product>();

        public ShoppingCart()
        {
            ShoppingCartId = GetCartId();
        }

        public string ShoppingCartId { get; }

        public void AddItem(Product product)
        {
            items.Add(product);
        }

        public IList<Product> GetCartItems()
        {
            return items;
        }

        public decimal GetCartTotal()
        {
            var subtotal = items.Sum(p => p.UnitPrice);

            if (!items.Any())
            {
                return 0;
            }

            return subtotal;
        }
        
        private string GetCartId()
        {
            return Guid.NewGuid().ToString();
        }
    }
}