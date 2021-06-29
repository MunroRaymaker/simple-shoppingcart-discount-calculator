using DiscountCalculator.Application.Promotion;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DiscountCalculator.Application.Model
{
    public class ShoppingCart : IShoppingCart
    {
        private readonly IPromotionCalculator promotionCalculator;
        private readonly List<Product> items = new List<Product>();

        public ShoppingCart(IPromotionCalculator promotionCalculator)
        {
            this.promotionCalculator = promotionCalculator ?? throw new ArgumentNullException(nameof(promotionCalculator));
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

        public decimal GetCartSubTotal()
        {
            var subtotal = items.Sum(p => p.UnitPrice);

            if (!items.Any())
            {
                return 0;
            }

            return subtotal;
        }

        public decimal GetTotalPromotions()
        {
            return promotionCalculator.CalculateTotalPromotions(this.items);
        }

        public decimal GetCartTotalWithPromotions()
        {
            return GetCartSubTotal() - GetTotalPromotions();
        }

        private string GetCartId()
        {
            return Guid.NewGuid().ToString();
        }
    }
}