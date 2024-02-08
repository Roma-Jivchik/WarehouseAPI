namespace WarehouseAPI.Domain.Requests.DepartmentWorkersRequests
{
    public class UpdateDepartmentWorkersRequest
    {
        public Guid Id { get; set; }
        public Guid DepartmentId { get; set; }
        public Guid WorkerId { get; set; }
    }
}
