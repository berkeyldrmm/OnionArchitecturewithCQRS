using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecturewithCQRS.Application
{
    public static class ServiceRegistration
    {
        public static void RegisterApplicationServices(this IServiceCollection serviceCollection)
        {
            var assembly = Assembly.GetExecutingAssembly();
            serviceCollection.AddAutoMapper(assembly);
            serviceCollection.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
        }
    }
}
