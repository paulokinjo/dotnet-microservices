namespace Catalog.Infrastructure.Data
{
    namespace Catalog.Infrastructure.Constants
    {
        internal static class DatabaseConstants
        {
            public const string ConnectionStringKey = "Mongo";
            public const string DatabaseSettingsSection = "DatabaseSettings";
            public const string DatabaseNameKey = $"{DatabaseSettingsSection}:DatabaseName";
            public const string ProductsCollectionNameKey = $"{DatabaseSettingsSection}:ProductsCollectionName";
            public const string BrandsCollectionNameKey = $"{DatabaseSettingsSection}:BrandsCollectionName";
            public const string TypesCollectionNameKey = $"{DatabaseSettingsSection}:TypesCollectionName";
        }
    }
}
