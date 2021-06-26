using System.Collections.Generic;
using System.Linq;
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

        public IList<Product> Products { get; set; } = new List<Product>();

        // Singleton pattern
        public static ApplicationDatabase Instance()
        {
            return instance;
        }

        public Product GetProductBySku(string sku)
        {
            return Products.SingleOrDefault(p => p.SKU.Equals(sku));
        }

        private void Seed()
        {
            Products.Add(new Product {SKU = "A", Name = "Apples", UnitPrice = 50});
            Products.Add(new Product {SKU = "B", Name = "Bananas", UnitPrice = 30});
            Products.Add(new Product {SKU = "C", Name = "Carrots", UnitPrice = 20});
            Products.Add(new Product {SKU = "D", Name = "Dates", UnitPrice = 15});
            Products.Add(new Product {SKU = "E", Name = "Eggplant", UnitPrice = 20});
        }
    }
}