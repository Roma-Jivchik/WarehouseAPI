using Mapster;
using WarehouseAPI.DAL.Repositories.ProductRepositories;
using WarehouseAPI.Domain.DTOs;
using WarehouseAPI.Domain.Entities;
using WarehouseAPI.Domain.Requests.ProductRequests;

namespace WarehouseAPI.BLL.Services.ProductServices
{
    internal class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
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
    }
}
