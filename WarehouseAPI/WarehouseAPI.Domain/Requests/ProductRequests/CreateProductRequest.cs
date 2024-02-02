namespace WarehouseAPI.Domain.Requests.ProductRequests;

public class CreateProductRequest
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Position { get; set; } = null!;
}