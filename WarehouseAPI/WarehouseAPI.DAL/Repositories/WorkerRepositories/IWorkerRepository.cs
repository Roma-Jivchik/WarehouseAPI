using WarehouseAPI.Domain.Entities;

namespace WarehouseAPI.DAL.Repositories.WorkerRepositories
{
    internal interface IWorkerRepository : IBaseRepository<Worker>
    {
        Task<Worker?> GetByLastNameAsync(string lastName);
        Task<List<Worker>> GetByPosition(string position);
    }
}
