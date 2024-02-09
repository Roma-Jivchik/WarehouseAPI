using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WarehouseAPI.BLL.Services.DepartmentWorkersServices;
using WarehouseAPI.Domain.Entities;
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
        [HttpPost("addWorkerToDepartment")]
        public async Task<ActionResult<DepartmentWorkers>> AddWorkerToDepartmentAsync([FromBody] CreateDepartmentWorkersRequest request)
        {
            var createdDepartmentWorkers = await _departmentWorkersService.AddWorkerToDepartmentAsync(request);

            return Ok(createdDepartmentWorkers);
        }

        [Authorize]
        [HttpDelete("deleteWorkerFromDepartment")]
        public async Task<ActionResult> DeleteWorkerFromDepartmentAsync([FromBody] DeleteDepartmentWorkersRequest deleteDepartmentWorkersRequest)
        {
            var isDelete = await _departmentWorkersService.DeleteWorkerFromDepartmentAsync(deleteDepartmentWorkersRequest);

            if (isDelete is false)
            {
                return BadRequest();
            }

            return Ok(isDelete);
        }

        [Authorize]
        [HttpPut("updateWorkerDepartment")]
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
