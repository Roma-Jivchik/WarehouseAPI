namespace WarehouseAPI.Domain.Requests.IdentityRequests;

public class RegisterRequest
{
    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;
}