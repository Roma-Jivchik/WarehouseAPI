namespace WarehouseAPI.Domain.DTOs
{
    public class DepartmentWorkersDto
    {
        public Guid Id { get; set; }
        public Guid DepartmentId { get; set; }
        public Guid WorkerId { get; set; }
    }
}
