using Inventory.Domain.Abstractions;
using Inventory.Domain.Exceptions;
using Inventory.Domain.Primitives;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Inventory.Infrastructure.DataAccess
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected readonly AppDbContext _dbContext;
        public Repository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = new())
        {
            await _dbContext.Set<TEntity>().AddAsync(entity, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return entity;

        }

        public async Task DeleteAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = new())
        {
            var dbSet = _dbContext.Set<TEntity>();
            var entity = await dbSet.Where(e => !e.IsDeleted).FirstOrDefaultAsync(expression, cancellationToken);
            
            if (entity == null)
                throw new EntityNotFoundException(typeof(TEntity).Name);

            entity.DeleteRecord();
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public IQueryable<TEntity> GetAll() => _dbContext.Set<TEntity>();

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            var dbSet = _dbContext.Set<TEntity>();
            return await dbSet.FirstOrDefaultAsync(e => e.Id == id && !e.IsDeleted);
        }

        public IQueryable<TEntity> GetQueryable(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbContext.Set<TEntity>().Where(c => !c.IsDeleted).Where(predicate);
        }

        public async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = new())
        {
            await _dbContext.SaveChangesAsync(cancellationToken);
            return entity;
        }
    }
}
