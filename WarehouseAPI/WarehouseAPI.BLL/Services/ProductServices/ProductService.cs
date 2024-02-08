using Mapster;
using WarehouseAPI.BLL.Exceptions;
using WarehouseAPI.BLL.Resources;
using WarehouseAPI.DAL.Repositories.DepartmentRepositories;
using WarehouseAPI.DAL.Repositories.ProductRepositories;
using WarehouseAPI.Domain.DTOs;
using WarehouseAPI.Domain.Entities;
using WarehouseAPI.Domain.Requests.DepartmentRequests;
using WarehouseAPI.Domain.Requests.ProductRequests;

namespace WarehouseAPI.BLL.Services.ProductServices
{
    internal class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IDepartmentRepository _departmentRepository;

        public ProductService(IProductRepository productRepository, IDepartmentRepository departmentRepository)
        {
            _productRepository = productRepository;
            _departmentRepository = departmentRepository;
        }

        public async Task<ProductDto?> CreateAsync(CreateProductRequest createProductRequest)
        {
            var productEntity = createProductRequest.Adapt<Product>();

            var createdProductEntity = await _productRepository.AddAsync(productEntity);

            return createdProductEntity.Adapt<ProductDto>();
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            return _productRepository.DeleteAsync(new Product { Id = id });
        }

        public async Task<List<ProductDto>> GetAllAsync()
        {
            var productEntities = await _productRepository.GetAsync();

            var mappedProducts = productEntities.Adapt<List<ProductDto>>();

            return mappedProducts;
        }

        public async Task<ProductDto?> GetProductAsync(Guid id)
        {
            var productEntity = await _productRepository.GetByIdAsync(id);

            var mappedProduct = productEntity?.Adapt<ProductDto>();

            return mappedProduct;
        }

        public async Task<ProductDto?> GetByNameAsync(string name)
        {
            var productEntity = await _productRepository.GetByName(name);

            var mappedProduct = productEntity?.Adapt<ProductDto>();

            return mappedProduct;
        }

        public async Task<List<ProductDto>?> GetByLowerPriceAsync(int price)
        {
            var productEntites = await _productRepository.GetByLowerPrice(price);

            var mappedProducts = productEntites?.Adapt<List<ProductDto>?>();

            return mappedProducts;
        }

        public async Task<bool> UpdateAsync(UpdateProductRequest updateProductRequest)
        {
            var productEntity = await _productRepository.GetByIdAsync(updateProductRequest.Id);

            if (productEntity is null)
            {
                return false;
            }

            updateProductRequest.Adapt(productEntity);

            await _productRepository.UpdateAsync(productEntity);

            return true;
        }

        public async Task<bool> AddProductToDepartmentAsync(string productName, int departmentNumber)
        {
            var productEntity = await GetByNameAsync(productName);

            if (productEntity is null)
            {
                throw new ValidationExceptionResult(ProductExceptionMessages.ProductNotExist);
            }

            var departmentEntity = await _departmentRepository.GetByNumber(departmentNumber);

            if (departmentEntity is null)
            {
                throw new ValidationExceptionResult(DepartmentExceptionMessages.DepartmentWithThisNumberIsNotExist);
            }

            productEntity.DepartmentId = departmentEntity.Id;

            var productDto = productEntity.Adapt<ProductDto>();

            var updateProductRequest = productDto.Adapt<UpdateProductRequest>();

            return await UpdateAsync(updateProductRequest);
        }
    }
}
