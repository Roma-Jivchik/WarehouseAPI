namespace WarehouseAPI.Domain.Requests.DepartmentWorkersRequests
{
    public class DeleteDepartmentWorkersRequest
    {
        public string WorkerLastName { get; set; } = null!;
        public int DepartmentNumber { get; set; }
    }
}
