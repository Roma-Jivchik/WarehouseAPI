using Microsoft.EntityFrameworkCore;
using WarehouseAPI.DAL.DataAccess;
using WarehouseAPI.Domain.Entities;

namespace WarehouseAPI.DAL.Repositories.DepartmentRepositories
{
    internal class DepartmentRepository : BaseRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(WarehouseDBContext warehouseDBContext) : base(warehouseDBContext)
        {

        }

        public Task<Department?> GetByName(string name)
        {
            return DbSet.AsNoTracking().FirstOrDefaultAsync(_ => _.Name == name);
        }

        public Task<Department?> GetByNumber(int number)
        {
            return DbSet.AsNoTracking().FirstOrDefaultAsync(_ => _.Number == number); ;
        }
    }
}
