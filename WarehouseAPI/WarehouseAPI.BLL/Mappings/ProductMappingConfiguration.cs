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
                .RequireDestinationMemberSource(true);

            config.NewConfig<CreateProductRequest, Product>()
                  .RequireDestinationMemberSource(true)
                  .Ignore(dest => dest.Id);

            config.NewConfig<UpdateProductRequest, Product>()
                .RequireDestinationMemberSource(true);
        }
    }
}
