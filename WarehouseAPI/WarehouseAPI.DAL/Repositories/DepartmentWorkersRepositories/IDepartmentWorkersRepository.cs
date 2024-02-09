using WarehouseAPI.Domain.Entities;

namespace WarehouseAPI.DAL.Repositories.DepartmentWorkersRepositories
{
    public interface IDepartmentWorkersRepository : IBaseRepository<DepartmentWorkers>
    {
        Task<DepartmentWorkers?> GetDepartmentWorkersAsync(Guid workerId, Guid departmentId);
    }
}
