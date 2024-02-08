using Mapster;
using WarehouseAPI.BLL.Exceptions;
using WarehouseAPI.BLL.Resources;
using WarehouseAPI.BLL.Services.DepartmentServices;
using WarehouseAPI.DAL.Repositories.DepartmentRepositories;
using WarehouseAPI.DAL.Repositories.WorkerRepositories;
using WarehouseAPI.Domain.DTOs;
using WarehouseAPI.Domain.Entities;
using WarehouseAPI.Domain.Requests.DepartmentRequests;
using WarehouseAPI.Domain.Requests.WorkerRequests;

namespace WarehouseAPI.BLL.Services.WorkerServices
{
    internal class WorkerService : IWorkerService
    {
        private readonly IWorkerRepository _workerRepository;

        public WorkerService(IWorkerRepository workerRepository)
        {
            _workerRepository = workerRepository;
        }

        public async Task<WorkerDto?> CreateAsync(CreateWorkerRequest createWorkerRequest)
        {
            var workerEntity = createWorkerRequest.Adapt<Worker>();

            var createdWorkerEntity = await _workerRepository.AddAsync(workerEntity);

            return createdWorkerEntity.Adapt<WorkerDto>();
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            return _workerRepository.DeleteAsync(new Worker { Id = id });
        }

        public async Task<List<WorkerDto>> GetAllAsync()
        {
            var workerEntities = await _workerRepository.GetAsync();

            var mappedWorkers = workerEntities.Adapt<List<WorkerDto>>();

            return mappedWorkers;
        }

        public async Task<WorkerDto?> GetWorkerAsync(Guid id)
        {
            var workerEntity = await _workerRepository.GetByIdAsync(id);

            var mappedWorker = workerEntity?.Adapt<WorkerDto>();

            return mappedWorker;
        }

        public async Task<WorkerDto?> GetWorkerByLastNameAsync(string lastName)
        {
            var workerEntity = await _workerRepository.GetByLastNameAsync(lastName);

            var mappedWorker = workerEntity?.Adapt<WorkerDto>();

            return mappedWorker;
        }

        public async Task<List<WorkerDto?>> GetWorkersByPositionAsync(string position)
        {
            var workerEntites = await _workerRepository.GetByPosition(position);

            var mappedWorkers = workerEntites?.Adapt<List<WorkerDto?>>();

            return mappedWorkers;
        }

        public async Task<bool> UpdateAsync(UpdateWorkerRequest updateWorkerRequest)
        {
            var workerEntity = await _workerRepository.GetByIdAsync(updateWorkerRequest.Id);

            if (workerEntity is null)
            {
                return false;
            }

            updateWorkerRequest.Adapt(workerEntity);

            await _workerRepository.UpdateAsync(workerEntity);

            return true;
        }
    }
}
