using Mapster;
using WarehouseAPI.Domain.DTOs;
using WarehouseAPI.Domain.Entities;
using WarehouseAPI.Domain.Requests.IdentityRequests;

namespace WarehouseAPI.BLL.Mappings
{
    internal class UserMappingConfiguration
    {
        public static void Register(TypeAdapterConfig config)
        {
            config.NewConfig<User, UserDto>()
                .RequireDestinationMemberSource(true);

            config.NewConfig<RegisterRequest, User>()
                .RequireDestinationMemberSource(true)
                .Ignore(_ => _.Id)
                .Ignore(_ => _.PasswordHash);
        }
    }
}
