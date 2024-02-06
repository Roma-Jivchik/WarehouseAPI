using Microsoft.EntityFrameworkCore;
using WarehouseAPI.DAL.DataAccess;
using WarehouseAPI.Domain.Entities;

namespace WarehouseAPI.DAL.Repositories.ProductRepositories
{
    internal class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(WarehouseDBContext warehouseDBContext) : base(warehouseDBContext)
        {

        }

        public Task<List<Product>> GetByLowerPrice(int price)
        {
            return DbSet.AsNoTracking()
                .Where(_ => _.Price < price)
                .OrderBy(_ => _.Price)
                .ToListAsync();
        }

        public Task<Product?> GetByName(string name)
        {
            return DbSet.AsNoTracking().FirstOrDefaultAsync(_ => _.Name == name);
        }
    }
}
