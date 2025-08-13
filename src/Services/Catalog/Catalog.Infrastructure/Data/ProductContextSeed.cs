using Catalog.Core.Entities;
using MongoDB.Driver;
using System.Text.Json;

namespace Catalog.Infrastructure.Data
{
    internal static class ProductContextSeed
    {
        public static async Task SeedData(IMongoCollection<Product> productCollection)
        {
            bool checkProducts = productCollection.Find(p => true).Any();
            if (!checkProducts)
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), "Data", "SeedData", "products.json");
                var productsData = File.ReadAllText(path);
                var products = JsonSerializer.Deserialize<IEnumerable<Product>>(productsData);
                if (products != null && products.Any())
                {
                    await productCollection.InsertManyAsync(products);
                }
            }
        }
    }
}
