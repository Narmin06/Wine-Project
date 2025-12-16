using System.Linq.Expressions;

namespace App.DAL.Repositories.Interfaces;

public interface IRepository<TEntity>
{
    // Read Repository Methods
    TEntity GetById(
        Expression<Func<TEntity, bool>> predicate,
        bool tracking = true,
        params Expression<Func<TEntity, object>>[]? includes);
    IQueryable<TEntity> GetAll(
        Expression<Func<TEntity, bool>> predicate,
        bool tracking = true,
        params Expression<Func<TEntity, object>>[] includes);

    // Write Repository Methods
    Task<TEntity> AddAsync(TEntity entity);
    Task AddRangeAsync(ICollection<TEntity> items);
    Task<TEntity> UpdateAsync(TEntity entity);
    Task<TEntity> DeleteAsync(TEntity entity);
    Task<TEntity> RecoverAsync(TEntity entity);
    Task<TEntity> RemoveAsync(TEntity entity);
    Task RemoveAll(ICollection<TEntity> items);

    // Soft Deletion and IsActive Methods
    Task<TEntity> SoftDeleteAsync(TEntity entity);
    Task<ICollection<TEntity>> SoftDeleteRangeAsync(ICollection<TEntity> items);
    Task<TEntity> ActivateAsync(TEntity entity);
    Task<TEntity> DeactivateAsync(TEntity entity);
    IQueryable<TEntity> GetAllActive(
        Expression<Func<TEntity, bool>> predicate,
        bool tracking = true,
        params Expression<Func<TEntity, object>>[] includes);
    IQueryable<TEntity> GetAllDeleted(
        Expression<Func<TEntity, bool>> predicate,
        bool tracking = true,
        params Expression<Func<TEntity, object>>[] includes);
}
