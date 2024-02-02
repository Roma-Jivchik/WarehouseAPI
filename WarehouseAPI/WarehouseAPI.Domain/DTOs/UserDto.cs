namespace WarehouseAPI.Domain.DTOs;

public class UserDto
{
    public Guid Id { get; set; }

    public string Login { get; set; } = null!;
}