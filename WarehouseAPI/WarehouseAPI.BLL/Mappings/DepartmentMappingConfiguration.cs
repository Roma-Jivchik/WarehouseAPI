using Mapster;
using WarehouseAPI.Domain.DTOs;
using WarehouseAPI.Domain.Entities;
using WarehouseAPI.Domain.Requests.DepartmentRequests;

namespace WarehouseAPI.BLL.Mappings
{
    internal class DepartmentMappingConfiguration
    {
        public static void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Department, DepartmentDto>()
                .RequireDestinationMemberSource(true);

            config.NewConfig<CreateDepartmentRequest, Department>()
                  .RequireDestinationMemberSource(true)
                  .Ignore(dest => dest.Id);

            config.NewConfig<UpdateDepartmentRequest, Department>()
                .RequireDestinationMemberSource(true);
        }
    }
}
