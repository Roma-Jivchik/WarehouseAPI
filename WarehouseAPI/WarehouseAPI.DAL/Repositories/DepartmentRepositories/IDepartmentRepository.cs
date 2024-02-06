using WarehouseAPI.Domain.Entities;

namespace WarehouseAPI.DAL.Repositories.DepartmentRepositories
{
    public interface IDepartmentRepository : IBaseRepository<Department>
    {
        Task<Department?> GetByNumber(int number);
        Task<Department?> GetByName(string name);
    }
}
