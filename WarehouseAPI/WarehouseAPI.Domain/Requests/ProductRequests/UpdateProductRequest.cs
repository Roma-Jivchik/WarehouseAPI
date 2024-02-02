namespace WarehouseAPI.Domain.Requests.ProductRequests;

public class UpdateProductRequest
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Position { get; set; } = null!;
}