namespace WarehouseAPI.Domain.Requests.ProductRequests;

public class CreateProductRequest
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int Price { get; set; }
    public int DepartmentNumber { get; set; }
}