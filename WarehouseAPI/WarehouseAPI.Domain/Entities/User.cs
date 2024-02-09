using System.ComponentModel.DataAnnotations.Schema;

namespace WarehouseAPI.Domain.Entities;

[Table(nameof(User))]
public class User : BaseEntity
{   
    public string Login { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;
}