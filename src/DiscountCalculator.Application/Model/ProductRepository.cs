using System.Collections.Generic;

namespace DiscountCalculator.Application.Model
{
    public class ProductRepository
    {
        private static readonly ProductRepository instance = new ProductRepository();

        private ProductRepository()
        {
            Seed();
        }

        public IDictionary<string, Product> Products { get; set; } = new Dictionary<string, Product>();
        
        public static ProductRepository Instance()
        {
            return instance;
        }

        public Product GetProductBySku(string sku)
        {
            Products.TryGetValue(sku, out var product);
            return product;
        }

        private void Seed()
        {
            Products.Add("A", new Product {SKU = "A", Name = "Apples", UnitPrice = 50});
            Products.Add("B", new Product {SKU = "B", Name = "Bananas", UnitPrice = 30});
            Products.Add("C", new Product {SKU = "C", Name = "Carrots", UnitPrice = 20});
            Products.Add("D", new Product {SKU = "D", Name = "Dates", UnitPrice = 15});
            Products.Add("E", new Product {SKU = "E", Name = "Eggplant", UnitPrice = 20});
        }
    }
}