using WarehouseAPI.Domain.DTOs;
using WarehouseAPI.Domain.Requests.WorkerRequests;

namespace WarehouseAPI.BLL.Services.WorkerServices
{
    public interface IWorkerService
    {
        Task<List<WorkerDto>> GetAllAsync();

        Task<WorkerDto?> GetWorkerAsync(Guid id);

        Task<WorkerDto?> GetWorkerByLastNameAsync(string lastName);

        Task<List<WorkerDto?>> GetWorkersByPositionAsync(string position);

        Task<WorkerDto?> CreateAsync(CreateWorkerRequest createWorkerRequest);

        Task<bool> UpdateAsync(UpdateWorkerRequest updateWorkerRequest);

        Task<bool> DeleteAsync(Guid id);
    }
}
