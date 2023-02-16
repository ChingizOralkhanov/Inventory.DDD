using Inventory.API.Products.Commands;
using Inventory.API.Products.Queries;
using Inventory.Domain.Abstractions;
using Inventory.Domain.Entities;
using Inventory.Domain.Exceptions;
using Inventory.Infrastructure.DataAccess;
using Inventory.Infrastructure.DataAccess.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Infrastructure.Extensions
{
    public static class StartupExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(serviceProvider =>
            {
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                var options = new DbContextOptionsBuilder<AppDbContext>()
                    .UseNpgsql(connectionString)
                    .Options;
                var context = new AppDbContext(options);
                return context;
            });
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
        }

        public static void ConfigureMediatR(this IServiceCollection services)
        {
            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<IRequestHandler<GetProductsQuery, IEnumerable<Product>>, GetProductsQueryHandler>();
            services.AddScoped<IRequestHandler<GetProductsCountByStatusQuery, int>, GetProductsCountByStatusQueryHandler>();
        }
    }
}
