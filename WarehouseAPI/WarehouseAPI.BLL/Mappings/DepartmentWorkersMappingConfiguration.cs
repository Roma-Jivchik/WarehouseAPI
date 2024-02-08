using Mapster;
using WarehouseAPI.Domain.DTOs;
using WarehouseAPI.Domain.Entities;
using WarehouseAPI.Domain.Requests.DepartmentWorkersRequests;

namespace WarehouseAPI.BLL.Mappings
{
    internal class DepartmentWorkersMappingConfiguration
    {
        public static void Register(TypeAdapterConfig config)
        {
            config.NewConfig<DepartmentWorkers, DepartmentWorkersDto>()
                .RequireDestinationMemberSource(true);

            config.NewConfig<CreateDepartmentWorkersRequest, DepartmentWorkers>()
                  .RequireDestinationMemberSource(true)
                  .Ignore(dest => dest.Id)
                  .Ignore(dest => dest.DepartmentId)
                  .Ignore(dest => dest.WorkerId);

            config.NewConfig<DeleteDepartmentWorkersRequest, DepartmentWorkers>()
                  .RequireDestinationMemberSource(true)
                  .Ignore(dest => dest.Id)
                  .Ignore(dest => dest.DepartmentId)
                  .Ignore(dest => dest.WorkerId);


            config.NewConfig<UpdateDepartmentWorkersRequest, DepartmentWorkers>()
                .RequireDestinationMemberSource(true)
                .Ignore(dest => dest.DepartmentId)
                .Ignore(dest => dest.WorkerId);
        }
    }
}
