using WarehouseAPI.Domain.Entities;

namespace WarehouseAPI.DAL.Repositories.ProductRepositories
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<Product?> GetByName(string name);
        Task<List<Product>> GetByLowerPrice(int price);
    }
}
