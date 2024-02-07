using Mapster;
using WarehouseAPI.Domain.DTOs;
using WarehouseAPI.Domain.Entities;
using WarehouseAPI.Domain.Requests.WorkerRequests;

namespace WarehouseAPI.BLL.Mappings
{
    internal class WorkerMappingConfiguration
    {
        public static void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Worker, WorkerDto>()
                .RequireDestinationMemberSource(true);

            config.NewConfig<CreateWorkerRequest, Worker>()
                  .RequireDestinationMemberSource(true)
                  .Ignore(dest => dest.Id);

            config.NewConfig<UpdateWorkerRequest, Worker>()
                .RequireDestinationMemberSource(true);
        }
    }
}
