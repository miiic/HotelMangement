using HotelManagement.Operations.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace HotelManagement.Infrastructure
{
    public static class InfrastructureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IHotelManagementDbContext, HotelManagementDbContext>();
            services.AddDbContext<HotelManagementDbContext>(
                options => options.UseSqlServer("name=ConnectionStrings:HotelManagementDbContext"));
            return services;
        }
    }
}
