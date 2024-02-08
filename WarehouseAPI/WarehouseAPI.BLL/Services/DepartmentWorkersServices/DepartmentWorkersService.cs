using Mapster;
using WarehouseAPI.BLL.Exceptions;
using WarehouseAPI.BLL.Resources;
using WarehouseAPI.DAL.Repositories.DepartmentRepositories;
using WarehouseAPI.DAL.Repositories.DepartmentWorkersRepositories;
using WarehouseAPI.DAL.Repositories.WorkerRepositories;
using WarehouseAPI.Domain.DTOs;
using WarehouseAPI.Domain.Entities;
using WarehouseAPI.Domain.Requests.DepartmentRequests;
using WarehouseAPI.Domain.Requests.DepartmentWorkersRequests;

namespace WarehouseAPI.BLL.Services.DepartmentWorkersServices
{
    internal class DepartmentWorkersService : IDepartmentWorkersService
    {
        private readonly IDepartmentWorkersRepository _departmentWorkersRepository;
        private readonly IWorkerRepository _workerRepository;
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentWorkersService(IDepartmentWorkersRepository departmentWorkersRepository, IWorkerRepository workerRepository, IDepartmentRepository departmentRepository)
        {
            _departmentWorkersRepository = departmentWorkersRepository;
            _workerRepository = workerRepository;
            _departmentRepository = departmentRepository;
        }

        public async Task<DepartmentWorkersDto?> AddWorkerToDepartmentAsync(string workerLastName, int departmentNumber)
        {
            var workerEntity = await _workerRepository.GetByLastNameAsync(workerLastName);

            if (workerEntity is null)
            {
                throw new ValidationExceptionResult(WorkerExceptionMessages.WorkerIsNotExist);
            }

            var departmentEntity = await _departmentRepository.GetByNumber(departmentNumber);

            if (departmentEntity is null)
            {
                throw new ValidationExceptionResult(DepartmentExceptionMessages.DepartmentWithThisNumberIsNotExist);
            }

            var createDepartmentWorkersRequest = new CreateDepartmentWorkersRequest(workerEntity.Id, departmentEntity.Id);

            return await CreateAsync(createDepartmentWorkersRequest);
        }

        public async Task<DepartmentWorkersDto?> CreateAsync(CreateDepartmentWorkersRequest createDepartmentWorkersRequest)
        {
            var departmentWorkersEntity = createDepartmentWorkersRequest.Adapt<DepartmentWorkers>();

            var createdDepartmentWorkersEntity = await _departmentWorkersRepository.AddAsync(departmentWorkersEntity);

            return createdDepartmentWorkersEntity.Adapt<DepartmentWorkersDto>();
        }

        public Task<bool> DeleteWorkerFromDepartmentAsync(Guid id)
        {
            return _departmentWorkersRepository.DeleteAsync(new DepartmentWorkers { Id = id });
        }

        public async Task<List<DepartmentWorkersDto>> GetAllAsync()
        {
            var departmentWorkersEntities = await _departmentWorkersRepository.GetAsync();

            var mappedDepartmentWorkers = departmentWorkersEntities.Adapt<List<DepartmentWorkersDto>>();

            return mappedDepartmentWorkers;
        }

        public async Task<bool> UpdateWorkerDepartmentAsync(UpdateDepartmentWorkersRequest updateDepartmentWorkersRequest)
        {
            var departmentWorkersEntity = await _departmentWorkersRepository.GetByIdAsync(updateDepartmentWorkersRequest.Id);

            if (departmentWorkersEntity is null)
            {
                return false;
            }

            updateDepartmentWorkersRequest.Adapt(departmentWorkersEntity);

            await _departmentWorkersRepository.UpdateAsync(departmentWorkersEntity);

            return true;
        }
    }
}
