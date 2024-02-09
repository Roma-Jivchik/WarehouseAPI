using WarehouseAPI.BLL;
using WarehouseAPI.DAL;
using FluentMigrator.Runner;
using WarehouseAPI.API.Filters;
using WarehouseAPI.API.Configurations;
using WebLibrary.API.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options =>
{
    options.Filters.Add<ApiExceptionFilterAttribute>();
});

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwagger();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddBLL();
builder.Services.AddDAL(connectionString);

builder.Services.AddJwtAuthentication(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    using var scope = app.Services.CreateScope();
    var services = scope.ServiceProvider;

    var runner = services.GetRequiredService<IMigrationRunner>();
    runner.MigrateUp();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
