using WarehouseAPI.Domain.Entities;

namespace WarehouseAPI.DAL.Repositories.WorkerRepositories
{
    public interface IWorkerRepository : IBaseRepository<Worker>
    {
        Task<Worker?> GetByLastNameAsync(string lastName);
        Task<List<Worker>> GetByPosition(string position);
    }
}
