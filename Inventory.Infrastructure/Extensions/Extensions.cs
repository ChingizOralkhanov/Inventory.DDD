using Inventory.Domain.Exceptions;
using Inventory.Infrastructure.DataAccess;
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
    public static class Extensions
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(serviceProvider =>
            {
                var connectionString = configuration.GetConnectionString("AppConnectionString");
                var options = new DbContextOptionsBuilder<AppDbContext>()
                    .UseNpgsql(connectionString)
                    .Options;
                var context = new AppDbContext(options);
                return context;
            });
        }
        public static async Task<TEntity> GetFirstOrDefaultAsync<TEntity>(this IQueryable<TEntity> query,
                                                                        Expression<Func<TEntity, bool>> fodExrpession,
                                                                        CancellationToken cancellationToken,
                                                                        bool throwException = true)
        {
            var entity = await query.FirstOrDefaultAsync(fodExrpession, cancellationToken);

            if (throwException)
            {
                if (entity is null)
                    throw new EntityNotFoundException(typeof(TEntity).Name);
            }

            return entity;
        }
    }
}
