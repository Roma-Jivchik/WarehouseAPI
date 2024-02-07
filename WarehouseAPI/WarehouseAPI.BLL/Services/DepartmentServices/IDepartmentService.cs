using WarehouseAPI.Domain.DTOs;
using WarehouseAPI.Domain.Requests.DepartmentRequests;

namespace WarehouseAPI.BLL.Services.DepartmentServices
{
    public interface IDepartmentService
    {
        Task<List<DepartmentDto>> GetAllAsync();

        Task<DepartmentDto?> GetDepartmentAsync(Guid id);

        Task<DepartmentDto?> CreateAsync(CreateDepartmentRequest createDepartmentRequest);

        Task<bool> UpdateAsync(UpdateDepartmentRequest updateDepartmentRequest);

        Task<bool> DeleteAsync(Guid id);

        Task<DepartmentDto?> GetDepartmentByNumberAsync(int number);

        Task<bool> AddWorkerToDepartmentAsync(string workerLastName, int departmentNumber);

        Task<DepartmentDto?> GetDepartmentByNameAsync(string name);

        Task<bool> AddProductToDepartmentAsync(string productName, int departmentNumber);
    }
}
