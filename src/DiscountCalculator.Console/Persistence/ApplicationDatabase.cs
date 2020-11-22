using System.Collections.Generic;
using DiscountCalculator.Console.Model;

namespace DiscountCalculator.Console.Persistence
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
        
        private void Seed()
        {
            this.Products.Add(new Product { SKU = "A", Name = "Apples", UnitPrice = 50 });
            this.Products.Add(new Product { SKU = "B", Name = "Bananas", UnitPrice = 30 });
            this.Products.Add(new Product { SKU = "C", Name = "Carrots", UnitPrice = 20 });
            this.Products.Add(new Product { SKU = "D", Name = "Dates", UnitPrice = 15 });
        }
    }
}
