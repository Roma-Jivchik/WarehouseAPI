using Mapster;
using WarehouseAPI.BLL.Exceptions;
using WarehouseAPI.BLL.Resources;
using WarehouseAPI.DAL.Repositories.DepartmentRepositories;
using WarehouseAPI.DAL.Repositories.DepartmentWorkersRepositories;
using WarehouseAPI.DAL.Repositories.DepartmentWorkersRepositories;
using WarehouseAPI.DAL.Repositories.WorkerRepositories;
using WarehouseAPI.Domain.DTOs;
using WarehouseAPI.Domain.Entities;
using WarehouseAPI.Domain.Requests.DepartmentWorkersRequests;
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

        public async Task<DepartmentWorkersDto?> AddWorkerToDepartmentAsync(CreateDepartmentWorkersRequest createDepartmentWorkersRequest)
        {
            var workerEntity = await _workerRepository.GetByLastNameAsync(createDepartmentWorkersRequest.WorkerLastName);

            if (workerEntity is null)
            {
                throw new ValidationExceptionResult(WorkerExceptionMessages.WorkerIsNotExist);
            }

            var departmentEntity = await _departmentRepository.GetByNumber(createDepartmentWorkersRequest.DepartmentNumber);

            if (departmentEntity is null)
            {
                throw new ValidationExceptionResult(DepartmentExceptionMessages.DepartmentWithThisNumberIsNotExist);
            }

            var departmentWorkers = new DepartmentWorkers()
            {
                Id = Guid.NewGuid(),
                DepartmentId = departmentEntity.Id,
                WorkerId = workerEntity.Id
            };

            return await CreateAsync(departmentWorkers);
        }

        public async Task<DepartmentWorkersDto?> CreateAsync(DepartmentWorkers departmentWorkers)
        {
            var createdDepartmentWorkersEntity = await _departmentWorkersRepository.AddAsync(departmentWorkers);

            return createdDepartmentWorkersEntity.Adapt<DepartmentWorkersDto>();
        }

        public async Task<bool> DeleteWorkerFromDepartmentAsync(DeleteDepartmentWorkersRequest deleteDepartmentWorkersRequest)
        {
            var workerEntity = await _workerRepository.GetByLastNameAsync(deleteDepartmentWorkersRequest.WorkerLastName);

            if (workerEntity is null)
            {
                throw new ValidationExceptionResult(WorkerExceptionMessages.WorkerIsNotExist);
            }

            var departmentEntity = await _departmentRepository.GetByNumber(deleteDepartmentWorkersRequest.DepartmentNumber);

            if (departmentEntity is null)
            {
                throw new ValidationExceptionResult(DepartmentExceptionMessages.DepartmentWithThisNumberIsNotExist);
            }

            var departmentWorkersEntity = await _departmentWorkersRepository.GetDepartmentWorkersAsync(workerEntity.Id, departmentEntity.Id);

            if(departmentWorkersEntity is null)
            {
                throw new ValidationExceptionResult(DepartmentWorkersMessages.ThereIsNoWorkerWhichWorkInThatDepartmentOrOpposite);
            }

            return await _departmentWorkersRepository.DeleteAsync(departmentWorkersEntity);
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
