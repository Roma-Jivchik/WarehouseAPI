using Mapster;
using MapsterMapper;
using System.Reflection;
using WarehouseAPI.BLL.Services.DepartmentServices;
using Microsoft.Extensions.DependencyInjection;
using WarehouseAPI.BLL.Services.IdentityServices;
using WarehouseAPI.BLL.Services.WorkerServices;
using WarehouseAPI.BLL.Services.ProductServices;
using WarehouseAPI.BLL.Services.DepartmentWorkersServices;

namespace WarehouseAPI.BLL
{
    public static class DI
    {
        public static IServiceCollection AddBLL(this IServiceCollection services)
        {
            RegisterMapster(services);

            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IWorkerService, WorkerService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IDepartmentWorkersService, DepartmentWorkersService>();

            return services;
        }

        private static void RegisterMapster(IServiceCollection services)
        {
            var typeAdapterConfig = TypeAdapterConfig.GlobalSettings;
            var applicationAssembly = Assembly.GetExecutingAssembly();
            typeAdapterConfig.Scan(applicationAssembly);

            services.AddSingleton(typeAdapterConfig);
            services.AddScoped<IMapper, ServiceMapper>();
        }
    }
}
