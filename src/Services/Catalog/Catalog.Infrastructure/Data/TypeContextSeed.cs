using Catalog.Core.Entities;
using MongoDB.Driver;
using System.Text.Json;

namespace Catalog.Infrastructure.Data
{
    internal static class TypeContextSeed
    {
        public static async Task SeedData(IMongoCollection<ProductType> typeCollection)
        {
            bool checkTypes = typeCollection.Find(b => true).Any();
            if (!checkTypes)
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), "Data", "SeedData", "product-types.json");
                var productTypesData = File.ReadAllText(path);
                var types = JsonSerializer.Deserialize<IEnumerable<ProductType>>(productTypesData);
                if (types != null && types.Any())
                {
                    await typeCollection.InsertManyAsync(types);
                }
            }
        }
    }
}
