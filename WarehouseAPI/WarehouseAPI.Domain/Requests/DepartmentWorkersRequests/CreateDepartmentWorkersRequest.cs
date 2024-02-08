namespace WarehouseAPI.Domain.Requests.DepartmentWorkersRequests
{
    public class CreateDepartmentWorkersRequest
    {
        public Guid DepartmentId { get; set; }
        public Guid WorkerId { get; set; }

        public CreateDepartmentWorkersRequest(Guid departmentId, Guid workerId)
        {
            DepartmentId = departmentId;
            WorkerId = workerId;
        }
    }
}
