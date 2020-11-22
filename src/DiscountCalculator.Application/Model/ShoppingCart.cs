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

            foreach (var discount in this.db.Discounts)
            {
                switch (discount.DiscountType)
                {
                    case DiscountType.FixedPriceForNDiscount:
                    
                        int eligibleItemsCount = this.items.Count(product => product.SKU == discount.SKU);
                        subtotal -= eligibleItemsCount / discount.Quantity * discount.Amount;

                        break;

                    case DiscountType.FixedPriceForTwoSkusDiscount:

                        var pairs = this.items.Where(i => i.SKU == discount.SKU[0].ToString())
                            .Zip(
                                this.items.Where(i => i.SKU == discount.SKU[1].ToString()),
                                (l, r) => new { Left = l, Right = r }).Count();

                        subtotal -= pairs * discount.Amount;
                        break;

                    case DiscountType.Percentage:
                        
                        subtotal -= Math.Round(this.items.Where(i => i.SKU == discount.SKU).Sum(i => i.UnitPrice) * discount.Amount, 2);
                        break;
                }
            }

            return subtotal;
        }

        private string GetCartId()
        {
            return Guid.NewGuid().ToString();
        }
    }
}