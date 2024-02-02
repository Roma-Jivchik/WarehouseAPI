using FluentMigrator;

namespace WarehouseAPI.Migrations;

[Migration(202402020001)]
public class InitializeTables : AutoReversingMigration
{
    public override void Up()
    {
        Create.Table("User")
            .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
            .WithColumn("Login").AsString(20).NotNullable()
            .WithColumn("PasswordHash").AsString(100).NotNullable();

        Create.Table("Department")
            .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
            .WithColumn("Name").AsString().NotNullable()
            .WithColumn("Descripiton").AsString().NotNullable()
            .WithColumn("Number").AsInt32().NotNullable();

        Create.Table("Worker")
            .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
            .WithColumn("FirstName").AsString().NotNullable()
            .WithColumn("LastName").AsString().NotNullable()
            .WithColumn("Position").AsString().NotNullable();

        Create.Table("Product")
            .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
            .WithColumn("Name").AsString().NotNullable()
            .WithColumn("Description").AsString().NotNullable()
            .WithColumn("Price").AsInt32().NotNullable()
            .WithColumn("DepartmentId").AsGuid().Unique().ForeignKey("Department", "Id").OnDeleteOrUpdate(System.Data.Rule.Cascade);

        Create.Table("DepartmentWorkers")
            .WithColumn("Id").AsGuid().PrimaryKey()
            .WithColumn("DepartmentId").AsGuid().ForeignKey("Department", "Id")
            .WithColumn("WorkerId").AsGuid().ForeignKey("Worker", "Id");
    }
}