namespace WarehouseAPI.Domain.Requests.DepartmentRequests
{
    internal class CreateDepartmentRequest
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int Number { get; set; }
    }
}
