using System.ComponentModel.DataAnnotations.Schema;

namespace WarehouseAPI.Domain.Entities
{
    [Table(nameof(Worker))]
    public class Worker : BaseEntity
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Position { get; set; } = null!;
        public List<DepartmentWorkers> DepartmentWorkers { get; } = new List<DepartmentWorkers>();
        public List<Department> Departments { get; } = new List<Department>();
    }
}
