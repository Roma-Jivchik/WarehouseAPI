using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WarehouseAPI.API.Models;
using WarehouseAPI.BLL.Services.ProductServices;
using WarehouseAPI.Domain.Entities;
using WarehouseAPI.Domain.Requests.ProductRequests;

namespace WarehouseAPI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAllProductsAsync()
        {
            var products = await _productService.GetAllAsync();

            return Ok(products);
        }

        [Authorize]
        [HttpPut]
        public async Task<ActionResult> AddProductToDepartmentAsync([FromBody] ProductAddingModel model)
        {
            var isAdded = await _productService.AddProductToDepartmentAsync(model.ProductName, model.DepartmentNumber);

            if (isAdded is false)
            {
                return BadRequest();
            }

            return Ok(isAdded);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductByIdAsync([FromRoute] Guid id)
        {
            var product = await _productService.GetProductAsync(id);

            if (product is null)
            {
                return NoContent();
            }

            return Ok(product);
        }

        [AllowAnonymous]
        [HttpGet("byName/{isbn}")]
        public async Task<ActionResult<Product?>> GetProductByNameAsync([FromRoute] string name)
        {
            var product = await _productService.GetByNameAsync(name);

            if (product is null)
            {
                return NoContent();
            }

            return Ok(product);
        }

        [AllowAnonymous]
        [HttpGet("byLowerPrice/{isbn}")]
        public async Task<ActionResult<List<Product?>>> GetProductByLowerPriceAsync([FromRoute] int price)
        {
            var products = await _productService.GetByLowerPriceAsync(price);

            if (products is null)
            {
                return NoContent();
            }

            return Ok(products);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> AddProductAsync([FromBody] CreateProductRequest request)
        {
            var createdProduct = await _productService.CreateAsync(request);

            return Ok(createdProduct);
        }

        [Authorize]
        [HttpPut]
        public async Task<ActionResult> UpdateProductAsync([FromBody] UpdateProductRequest request)
        {
            var isUpdate = await _productService.UpdateAsync(request);

            if (isUpdate is false)
            {
                return BadRequest();
            }

            return Ok(isUpdate);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProductAsync([FromRoute] Guid id)
        {
            var isDelete = await _productService.DeleteAsync(id);

            if (isDelete is false)
            {
                return BadRequest();
            }

            return Ok(isDelete);
        }
    }
}
