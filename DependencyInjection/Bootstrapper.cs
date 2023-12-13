using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DependencyInjection
{
    public static class Bootstrapper
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
        }
    }
}
