using Mapster;
using WarehouseAPI.Domain.DTOs;
using WarehouseAPI.Domain.Entities;
using WarehouseAPI.Domain.Requests.ProductRequests;

namespace WarehouseAPI.BLL.Mappings
{
    internal class ProductMappingConfiguration
    {
        public static void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Product, ProductDto>()
                .RequireDestinationMemberSource(true)
                .Ignore(dest => dest.DepartmentNumber);

            config.NewConfig<CreateProductRequest, Product>()
                  .RequireDestinationMemberSource(true)
                  .Ignore(dest => dest.Id)
                  .Ignore(dest => dest.DepartmentId);

            config.NewConfig<UpdateProductRequest, Product>()
                .RequireDestinationMemberSource(true)
                .Ignore(dest => dest.DepartmentId);
        }
    }
}
