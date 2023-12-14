using Application;
using Application.Interfaces;
using DomainModel.Products.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public static class DependencyInjection
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("Db"),
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped<IApplicationDbContext, ApplicationDbContext>();

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUnitOfWork , UnitOfWork>();
        }
    }
}
