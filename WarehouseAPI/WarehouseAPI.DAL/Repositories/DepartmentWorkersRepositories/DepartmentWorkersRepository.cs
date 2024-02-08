using Microsoft.EntityFrameworkCore;
using WarehouseAPI.DAL.DataAccess;
using WarehouseAPI.Domain.Entities;

namespace WarehouseAPI.DAL.Repositories.DepartmentWorkersRepositories
{
    internal class DepartmentWorkersRepository : BaseRepository<DepartmentWorkers>, IDepartmentWorkersRepository
    {
        public DepartmentWorkersRepository(WarehouseDBContext warehouseDBContext) : base(warehouseDBContext)
        {

        }

        public Task<DepartmentWorkers?> GetDepartmentWorkersAsync(Guid workerId, Guid departmentId)
        {
            return DbSet.AsNoTracking().FirstOrDefaultAsync(_ => _.WorkerId == workerId && _.DepartmentId == departmentId);
        }
    }
}
