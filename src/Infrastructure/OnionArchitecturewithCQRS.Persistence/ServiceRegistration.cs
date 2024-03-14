using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OnionArchitecturewithCQRS.Application.Interfaces.Repository;
using OnionArchitecturewithCQRS.Application.Interfaces.UnitOfWork;
using OnionArchitecturewithCQRS.Persistence.Context;
using OnionArchitecturewithCQRS.Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecturewithCQRS.Persistence
{
    public static class ServiceRegistration
    {
        public static void RegisterPersistenceServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<ApplicationDbContext>(opt => opt.UseInMemoryDatabase("ApplicationMemoryDb"));

            serviceCollection.AddScoped<IProductRepository, ProductRepository>();
        }
    }
}
