namespace WarehouseAPI.Domain.Requests.DepartmentWorkersRequests
{
    public class UpdateDepartmentWorkersRequest
    {
        public Guid Id { get; set; }
        public string WorkerLastName { get; set; } = null!;
        public int DepartmentNumber { get; set; }
    }
}
