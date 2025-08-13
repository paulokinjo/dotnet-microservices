using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using Catalog.Infrastructure.Data.Catalog.Infrastructure.Constants;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Data
{
    public class CatalogContext : ICatalogContext
    {
        public IMongoCollection<Product> Products { get; }

        public IMongoCollection<ProductBrand> Brands { get; } 

        public IMongoCollection<ProductType> Types { get; }

        public CatalogContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetConnectionString(DatabaseConstants.ConnectionStringKey));
            var database = client.GetDatabase(configuration.GetSection(DatabaseConstants.DatabaseNameKey).Value);

            Products = database.GetCollection<Product>(configuration.GetSection(DatabaseConstants.ProductsCollectionNameKey).Value);
            Brands = database.GetCollection<ProductBrand>(configuration.GetSection(DatabaseConstants.BrandsCollectionNameKey).Value);
            Types = database.GetCollection<ProductType>(configuration.GetSection(DatabaseConstants.TypesCollectionNameKey).Value);

            BrandContextSeed.SeedData(Brands)
                .ContinueWith(_ => TypeContextSeed.SeedData(Types))
                .ContinueWith(_ => ProductContextSeed.SeedData(Products));
        }
    }
}
