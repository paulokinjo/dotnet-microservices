using Catalog.Core.Entities;

namespace Catalog.Core.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProducts();

        Task<Product> GetProductById(string id);

        Task<IEnumerable<Product>> GetProductsByType(string typeId);

        Task<IEnumerable<Product>> GetProductsByBrand(string brandId);

        Task CreateProduct(Product product);

        Task UpdateProduct(Product product);

        Task DeleteProduct(string id);
    }
}
