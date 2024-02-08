using FluentMigrator.Runner;
using WarehouseAPI.Migrations;
using WarehouseAPI.DAL.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WarehouseAPI.DAL.Repositories.WorkerRepositories;
using WarehouseAPI.DAL.Repositories.ProductRepositories;
using WarehouseAPI.DAL.Repositories.DepartmentRepositories;
using WarehouseAPI.DAL.Repositories.UserRepositories;

namespace WarehouseAPI.DAL
{
    public static class DI
    {
        public static void AddDAL(this IServiceCollection serviceCollection, string connectionString)
        {
            serviceCollection.AddDbContext<WarehouseDBContext>(options => options.UseSqlServer(connectionString));

            serviceCollection.AddFluentMigratorCore()
                .ConfigureRunner(runner => runner
                .AddSqlServer()
                .WithGlobalConnectionString(connectionString)
                .ScanIn(typeof(InitializeTables).Assembly).For.Migrations());

            serviceCollection.AddScoped<IWorkerRepository, WorkerRepository>();
            serviceCollection.AddScoped<IDepartmentRepository, DepartmentRepository>();
            serviceCollection.AddScoped<IProductRepository, ProductRepository>();
            serviceCollection.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
