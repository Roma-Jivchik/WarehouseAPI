using WarehouseAPI.Domain.DTOs;
using WarehouseAPI.Domain.Entities;
using WarehouseAPI.Domain.Requests.DepartmentWorkersRequests;

namespace WarehouseAPI.BLL.Services.DepartmentWorkersServices
{
    public interface IDepartmentWorkersService
    {
        Task<DepartmentWorkersDto?> CreateAsync(DepartmentWorkers departmentWorkers);

        Task<bool> UpdateWorkerDepartmentAsync(UpdateDepartmentWorkersRequest updateDepartmentWorkersRequest);

        Task<bool> DeleteWorkerFromDepartmentAsync(DeleteDepartmentWorkersRequest deleteDepartmentWorkersRequest);

        Task<DepartmentWorkersDto?> AddWorkerToDepartmentAsync(CreateDepartmentWorkersRequest createDepartmentWorkersRequest);
    }
}
