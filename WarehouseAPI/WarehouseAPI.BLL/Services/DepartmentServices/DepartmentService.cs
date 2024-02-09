using WarehouseAPI.BLL.Exceptions;
using WarehouseAPI.DAL.Repositories.DepartmentRepositories;
using WarehouseAPI.Domain.DTOs;
using WarehouseAPI.Domain.Entities;
using WarehouseAPI.Domain.Requests.DepartmentRequests;
using WarehouseAPI.BLL.Resources;
using Mapster;

namespace WarehouseAPI.BLL.Services.DepartmentServices
{
    internal class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<DepartmentDto?> CreateAsync(CreateDepartmentRequest createDepartmentRequest)
        {
            var existingDepartment = await _departmentRepository.GetByNumber(createDepartmentRequest.Number);

            if(existingDepartment is not null)
            {
                throw new ValidationExceptionResult(DepartmentExceptionMessages.DepartmentWithThisNumberAlsoExist);
            }

            var departmentEntity = createDepartmentRequest.Adapt<Department>();

            departmentEntity.Id = Guid.NewGuid();

            var createdDepartmentEntity = await _departmentRepository.AddAsync(departmentEntity);

            return createdDepartmentEntity.Adapt<DepartmentDto>();
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            return _departmentRepository.DeleteAsync(new Department { Id = id });
        }

        public async Task<List<DepartmentDto>> GetAllAsync()
        {
            var departmentEntities = await _departmentRepository.GetAsync();

            var mappedDepartments = departmentEntities.Adapt<List<DepartmentDto>>();

            return mappedDepartments;
        }

        public async Task<DepartmentDto?> GetDepartmentByNameAsync(string name)
        {
            var departmentEntity = await _departmentRepository.GetByName(name);

            var mappedDepartment = departmentEntity?.Adapt<DepartmentDto>();

            return mappedDepartment;
        }

        public async Task<DepartmentDto?> GetDepartmentByNumberAsync(int number)
        {
            var departmentEntity = await _departmentRepository.GetByNumber(number);

            var mappedDepartment = departmentEntity?.Adapt<DepartmentDto>();

            return mappedDepartment;
        }

        public async Task<DepartmentDto?> GetDepartmentAsync(Guid id)
        {
            var departmentEntity = await _departmentRepository.GetByIdAsync(id);

            var mappedDepartment = departmentEntity?.Adapt<DepartmentDto>();

            return mappedDepartment;
        }

        public async Task<bool> UpdateAsync(UpdateDepartmentRequest updateDepartmentRequest)
        {
            var departmentEntity = await _departmentRepository.GetByIdAsync(updateDepartmentRequest.Id);

            if (departmentEntity is null)
            {
                return false;
            }

            updateDepartmentRequest.Adapt(departmentEntity);

            await _departmentRepository.UpdateAsync(departmentEntity);

            return true;
        }
    }
}
