using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WarehouseAPI.BLL.Services.DepartmentServices;
using WarehouseAPI.Domain.Entities;
using WarehouseAPI.Domain.Requests.DepartmentRequests;

namespace WarehouseAPI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<List<Department>>> GetAllDepartmentsAsync()
        {
            var departments = await _departmentService.GetAllAsync();

            return Ok(departments);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<Department>> GetDepartmentByIdAsync([FromRoute] Guid id)
        {
            var department = await _departmentService.GetDepartmentAsync(id);

            if (department is null)
            {
                return NoContent();
            }

            return Ok(department);
        }

        [AllowAnonymous]
        [HttpGet("byName/{isbn}")]
        public async Task<ActionResult<Department?>> GetDepartmentByNameAsync([FromRoute] string lastName)
        {
            var department = await _departmentService.GetDepartmentByNameAsync(lastName);

            if (department is null)
            {
                return NoContent();
            }

            return Ok(department);
        }

        [AllowAnonymous]
        [HttpGet("byNumber/{isbn}")]
        public async Task<ActionResult<Department?>> GetDepartmentByNumberAsync([FromRoute] int number)
        {
            var departments = await _departmentService.GetDepartmentByNumberAsync(number);

            if (departments is null)
            {
                return NoContent();
            }

            return Ok(departments);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> AddDepartmentAsync([FromBody] CreateDepartmentRequest request)
        {
            var createdDepartment = await _departmentService.CreateAsync(request);

            return Ok(createdDepartment);
        }

        [Authorize]
        [HttpPut]
        public async Task<ActionResult> UpdateDepartmentAsync([FromBody] UpdateDepartmentRequest request)
        {
            var isUpdate = await _departmentService.UpdateAsync(request);

            if (isUpdate is false)
            {
                return BadRequest();
            }

            return Ok(isUpdate);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDepartmentAsync([FromRoute] Guid id)
        {
            var isDelete = await _departmentService.DeleteAsync(id);

            if (isDelete is false)
            {
                return BadRequest();
            }

            return Ok(isDelete);
        }
    }
}
