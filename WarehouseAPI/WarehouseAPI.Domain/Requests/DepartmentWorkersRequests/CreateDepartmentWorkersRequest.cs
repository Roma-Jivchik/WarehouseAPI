namespace WarehouseAPI.Domain.Requests.DepartmentWorkersRequests
{
    public class CreateDepartmentWorkersRequest
    {
        public string WorkerLastName { get; set; } = null!;
        public int DepartmentNumber { get; set; }
    }
}
