using Microsoft.EntityFrameworkCore;
using WarehouseAPI.Domain.Entities;

namespace WarehouseAPI.DAL.DataAccess;

internal class WarehouseDBContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;

    public DbSet<Worker> Workers { get; set; } = null!;

    public DbSet<Department> Departments { get; set; } = null!;

    public DbSet<Product> Products { get; set; } = null!;

    public DbSet<DepartmentWorkers> DepartmentWorkers { get; set; } = null!;

    public WarehouseDBContext(DbContextOptions<WarehouseDBContext> options)
        : base(options)
    {

    }
}
