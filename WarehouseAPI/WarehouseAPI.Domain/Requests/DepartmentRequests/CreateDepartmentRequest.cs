namespace WarehouseAPI.Domain.Requests.DepartmentRequests
{
    public class CreateDepartmentRequest
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int Number { get; set; }
    }
}
