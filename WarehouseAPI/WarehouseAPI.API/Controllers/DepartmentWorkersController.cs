using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WarehouseAPI.API.Models;
using WarehouseAPI.BLL.Services.DepartmentServices;
using WarehouseAPI.BLL.Services.DepartmentWorkersServices;
using WarehouseAPI.Domain.Entities;
using WarehouseAPI.Domain.Requests.DepartmentRequests;
using WarehouseAPI.Domain.Requests.DepartmentWorkersRequests;

namespace WarehouseAPI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentWorkersController : ControllerBase
    {
        private readonly IDepartmentWorkersService _departmentWorkersService;

        public DepartmentWorkersController(IDepartmentWorkersService departmentWorkersService)
        {
            _departmentWorkersService = departmentWorkersService;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<DepartmentWorkers>> AddWorkerToDepartmentAsync([FromBody] WorkerAddingModel model)
        {
            var createdDepartmentWorkers = await _departmentWorkersService.AddWorkerToDepartmentAsync(model.WorkerLastName, model.DepartmentNumber);

            return Ok(createdDepartmentWorkers);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteWorkerFromDepartmentAsync([FromRoute] Guid id)
        {
            var isDelete = await _departmentWorkersService.DeleteWorkerFromDepartmentAsync(id);

            if (isDelete is false)
            {
                return BadRequest();
            }

            return Ok(isDelete);
        }

        [Authorize]
        [HttpPut]
        public async Task<ActionResult> UpdateWorkerDepartmentAsync([FromBody] UpdateDepartmentWorkersRequest request)
        {
            var isUpdate = await _departmentWorkersService.UpdateWorkerDepartmentAsync(request);

            if (isUpdate is false)
            {
                return BadRequest();
            }

            return Ok(isUpdate);
        }
    }
}
