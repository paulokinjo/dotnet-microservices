using Catalog.Core.Entities;
using MongoDB.Driver;
using System.Text.Json;

namespace Catalog.Infrastructure.Data
{
    internal static class BrandContextSeed
    {
        public static async Task SeedData(IMongoCollection<ProductBrand> brandCollection)
        {
            bool checkBrands = brandCollection.Find(b => true).Any();
            if (!checkBrands)
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), "Data", "SeedData", "brands.json");
                var brandsData = File.ReadAllText(path);
                var brands = JsonSerializer.Deserialize<IEnumerable<ProductBrand>>(brandsData);
                if (brands != null && brands.Any())
                {
                    await brandCollection.InsertManyAsync(brands);
                }
            }
        }
    }
}
