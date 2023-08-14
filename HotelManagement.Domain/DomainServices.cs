using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace HotelManagement.Domain
{
    public static class DomainServices
    {
        public static IServiceCollection Add(this IServiceCollection services)
        {
            return services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
