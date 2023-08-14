using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace HotelManagement.Domain
{
    public static class DomainServices
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            return services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
