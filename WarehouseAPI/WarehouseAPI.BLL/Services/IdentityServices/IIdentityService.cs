using WarehouseAPI.Domain.DTOs;
using WarehouseAPI.Domain.Requests.IdentityRequests;

namespace WarehouseAPI.BLL.Services.IdentityServices
{
    public interface IIdentityService
    {
        Task<AuthenticationResult> LoginAsync(LoginRequest request);

        Task<AuthenticationResult> RegisterAsync(RegisterRequest request);
    }
}
