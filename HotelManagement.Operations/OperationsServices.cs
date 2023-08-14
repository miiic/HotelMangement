using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace HotelManagement.Operations
{
    public static class OperationsServices
    {
        public static IServiceCollection AddOperationsServices(this IServiceCollection services)
        {
            return services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        }
    }
}
