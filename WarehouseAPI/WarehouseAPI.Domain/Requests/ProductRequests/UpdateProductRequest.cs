namespace WarehouseAPI.Domain.Requests.ProductRequests;

public class UpdateProductRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int Price { get; set; }
    public int DepartmentNumber { get; set; }
}