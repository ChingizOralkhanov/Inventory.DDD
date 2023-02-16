using Inventory.Domain.Primitives;
using System.Linq.Expressions;


namespace Inventory.Domain.Abstractions
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> GetQueryable(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> GetByIdAsync(Guid id);
        Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = new());
        Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = new());
        Task DeleteAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = new());
    }
}
