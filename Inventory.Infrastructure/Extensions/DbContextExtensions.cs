using Inventory.Domain.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Infrastructure.Extensions
{
    public static class DbContextExtensions
    {
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
