using WarehouseAPI.Domain.DTOs;
using WarehouseAPI.Domain.Requests.DepartmentWorkersRequests;

namespace WarehouseAPI.BLL.Services.DepartmentWorkersServices
{
    public interface IDepartmentWorkersService
    {
        Task<List<DepartmentWorkersDto>> GetAllAsync();

        Task<DepartmentWorkersDto?> CreateAsync(CreateDepartmentWorkersRequest createDepartmentWorkersRequest);

        Task<bool> UpdateWorkerDepartmentAsync(UpdateDepartmentWorkersRequest updateDepartmentWorkersRequest);

        Task<bool> DeleteWorkerFromDepartmentAsync(Guid id);

        Task<DepartmentWorkersDto?> AddWorkerToDepartmentAsync(string workerLastName, int departmentNumber);
    }
}
