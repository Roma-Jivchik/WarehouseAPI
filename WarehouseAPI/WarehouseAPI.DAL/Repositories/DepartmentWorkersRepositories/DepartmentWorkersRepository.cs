using WarehouseAPI.DAL.DataAccess;
using WarehouseAPI.Domain.Entities;

namespace WarehouseAPI.DAL.Repositories.DepartmentWorkersRepositories
{
    internal class DepartmentWorkersRepository : BaseRepository<DepartmentWorkers>, IDepartmentWorkersRepository
    {
        public DepartmentWorkersRepository(WarehouseDBContext warehouseDBContext) : base(warehouseDBContext)
        {

        }
    }
}
