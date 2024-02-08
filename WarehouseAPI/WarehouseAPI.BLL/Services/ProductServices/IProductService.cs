using WarehouseAPI.Domain.DTOs;
using WarehouseAPI.Domain.Requests.ProductRequests;

namespace WarehouseAPI.BLL.Services.ProductServices
{
    public interface IProductService
    {
        Task<List<ProductDto>> GetAllAsync();

        Task<ProductDto?> GetProductAsync(Guid id);

        Task<ProductDto?> CreateAsync(CreateProductRequest createProductRequest);

        Task<bool> UpdateAsync(UpdateProductRequest updateProductRequest);

        Task<bool> DeleteAsync(Guid id);

        Task<ProductDto?> GetByNameAsync(string name);

        Task<List<ProductDto>?> GetByLowerPriceAsync(int price);

        Task<bool> AddProductToDepartmentAsync(string productName, int departmentNumber);
    }
}
