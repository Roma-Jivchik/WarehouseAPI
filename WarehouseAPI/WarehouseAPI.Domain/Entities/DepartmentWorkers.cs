using System.ComponentModel.DataAnnotations.Schema;

namespace WarehouseAPI.Domain.Entities
{
    [Table(nameof(DepartmentWorkers))]
    public class DepartmentWorkers : BaseEntity
    {
        public Guid DepartmentId { get; set; }
        public Guid WorkerId { get; set; }
        public Department Department { get; set; } = null!;
        public Worker Worker { get; set; } = null!;
    }
}
