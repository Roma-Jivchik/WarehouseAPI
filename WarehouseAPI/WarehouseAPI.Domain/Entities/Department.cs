using System.ComponentModel.DataAnnotations.Schema;

namespace WarehouseAPI.Domain.Entities
{
    [Table(nameof(Department))]
    public class Department : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int Number { get; set; }
        public Product? Product { get; set; }
        public List<Worker> Workers { get; set; } = new List<Worker>();
    }
}
