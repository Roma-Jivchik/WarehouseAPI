using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WarehouseAPI.BLL.Services.WorkerServices;
using WarehouseAPI.Domain.Entities;
using WarehouseAPI.Domain.Requests.WorkerRequests;

namespace WarehouseAPI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkerController : ControllerBase
    {
        private readonly IWorkerService _workerService;

        public WorkerController(IWorkerService workerService)
        {
            _workerService = workerService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<List<Worker>>> GetAllWorkersAsync()
        {
            var workers = await _workerService.GetAllAsync();

            return Ok(workers);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<Worker>> GetWorkerByIdAsync([FromRoute] Guid id)
        {
            var worker = await _workerService.GetWorkerAsync(id);

            if (worker is null)
            {
                return NoContent();
            }

            return Ok(worker);
        }

        [AllowAnonymous]
        [HttpGet("byLastName/{lastName}")]
        public async Task<ActionResult<Worker?>> GetWorkerByNameAsync([FromRoute] string lastName)
        {
            var worker = await _workerService.GetWorkerByLastNameAsync(lastName);

            if (worker is null)
            {
                return NoContent();
            }

            return Ok(worker);
        }

        [AllowAnonymous]
        [HttpGet("byLowerPrice/{position}")]
        public async Task<ActionResult<List<Worker?>>> GetWorkersByPositionAsync([FromRoute] string position)
        {
            var workers = await _workerService.GetWorkersByPositionAsync(position);

            if (workers is null)
            {
                return NoContent();
            }

            return Ok(workers);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> AddWorkerAsync([FromBody] CreateWorkerRequest request)
        {
            var createdWorker = await _workerService.CreateAsync(request);

            return Ok(createdWorker);
        }

        [Authorize]
        [HttpPut]
        public async Task<ActionResult> UpdateWorkerAsync([FromBody] UpdateWorkerRequest request)
        {
            var isUpdate = await _workerService.UpdateAsync(request);

            if (isUpdate is false)
            {
                return BadRequest();
            }

            return Ok(isUpdate);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteWorkerAsync([FromRoute] Guid id)
        {
            var isDelete = await _workerService.DeleteAsync(id);

            if (isDelete is false)
            {
                return BadRequest();
            }

            return Ok(isDelete);
        }
    }
}
