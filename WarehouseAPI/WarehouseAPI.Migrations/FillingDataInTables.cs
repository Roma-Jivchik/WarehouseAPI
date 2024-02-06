using FluentMigrator;
using WarehouseAPI.Domain.Entities;

namespace WarehouseAPI.Migrations;

[Migration(202402020002)]
public class FillingDataInTables : Migration
{
    private readonly User user = new User()
    {
        Id = Guid.NewGuid(),
        Login = "YaYoo",
        PasswordHash = "$FORMALHASH$V1$10000$LJ6mpiEhYgaF2RIIsE9DWOS3LjhzLNtWlSMVfEJ6120vF7i0"
    };

    private static readonly Worker worker = new Worker()
    {
        Id = Guid.NewGuid(),
        FirstName = "Some name",
        LastName = "Some last name",
        Position = "Some position"
    };

    private static Department department = new Department()
    {
        Id = Guid.NewGuid(),
        Name = "Department №1",
        Number = 1,
        Description = "Some description"
    };

    private readonly Product product = new Product()
    {
        Id = Guid.NewGuid(),
        Name = "Some name",
        Price = 100,
        Description = "Some description",
        Department = department,
        DepartmentId = department.Id
    };

    public override void Up()
    {
        Insert.IntoTable("User").Row(user);
        Insert.IntoTable("Worker").Row(worker);
        Insert.IntoTable("Department").Row(department);
        Insert.IntoTable("Product").Row(product);
    }

    public override void Down()
    {
        Delete.FromTable("User").Row(user);
        Delete.FromTable("Worker").Row(worker);
        Delete.FromTable("Department").Row(department);
        Delete.FromTable("Product").Row(product);
    }
}