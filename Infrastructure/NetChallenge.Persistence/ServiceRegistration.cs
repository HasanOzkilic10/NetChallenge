using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetChallenge.Application.Abstractions;
using NetChallenge.Persistence.Concretes;
using NetChallenge.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetChallenge.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceManagers(this IServiceCollection services)
        {
            //services.AddDbContext<NetChallengeDbContext>(options => options.UseSqlServer(@"Server=localhost;Database=Deneme37;Trusted_Connection=true;Encrypt =false"));
            // services.AddDbContext<NetChallengeDbContext>(options => options.UseSqlServer)
            services.AddSingleton<IProductRepository, ProductRepository>();
            services.AddSingleton<ICompanyRepository, CompanyRepository>();
            services.AddSingleton<IOrderRepository, OrderRepository>();

            services.AddSingleton<IProductService, ProductManager>();
            services.AddSingleton<ICompanyService, CompanyManager>();
            services.AddSingleton<IOrderService, OrderManager>();
            
        }
    }
}
