﻿using FluentMigrator.Runner;
using WebLibrary.Migrations;
using WebLibrary.DAL.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebLibrary.DAL.Repositories.BookRepositories;
using WebLibrary.DAL.Repositories.UserRepositories;

namespace WebLibrary.DAL
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

            serviceCollection.AddScoped<IBookRepository, BookRepository>();
            serviceCollection.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
