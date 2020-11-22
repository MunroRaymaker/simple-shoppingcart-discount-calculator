using System.Collections.Generic;
using DiscountCalculator.Application.Model;

namespace DiscountCalculator.Application.Persistence
{
    public class ApplicationDatabase
    {
        private static readonly ApplicationDatabase instance = new ApplicationDatabase();

        private ApplicationDatabase()
        {
            Seed();
        }

        public static ApplicationDatabase Instance() => instance;
        
        public IList<Product> Products { get; set; } = new List<Product>();

        public IList<Discount> Discounts { get; set; } = new List<Discount>();
        
        private void Seed()
        {
            this.Products.Add(new Product { SKU = "A", Name = "Apples", UnitPrice = 50 });
            this.Products.Add(new Product { SKU = "B", Name = "Bananas", UnitPrice = 30 });
            this.Products.Add(new Product { SKU = "C", Name = "Carrots", UnitPrice = 20 });
            this.Products.Add(new Product { SKU = "D", Name = "Dates", UnitPrice = 15 });

            // Adds discounts by "reversing" the logic. Eg. a fixed price of 130 for three A's would equal a deduction of 20 for 3.
            this.Discounts.Add(new Discount {SKU = "A", Amount = 20, Quantity = 3});
            this.Discounts.Add(new Discount {SKU = "B", Amount = 15, Quantity = 2});
            this.Discounts.Add(new Discount {SKU = "CD", Amount = 5, Quantity = 1});
        }
    }
}
