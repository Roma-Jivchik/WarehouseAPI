namespace WarehouseAPI.Domain.Requests.DepartmentRequests
{
    internal class UpdateDepartmentRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int Number { get; set; }
    }
}
