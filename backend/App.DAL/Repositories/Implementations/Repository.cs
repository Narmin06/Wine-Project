using App.Core.Entities.Commons;
using App.Core.Exceptions.Commons;
using App.DAL.Presistence;
using App.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace App.DAL.Repositories.Abstractions;

public class Repository<TEntity> : IRepository<TEntity>, IDisposable where TEntity : AuditableEntity
{
    protected readonly AppDbContext Context;
    protected readonly DbSet<TEntity> DbSet;
    private bool _disposed = false;

    protected Repository(AppDbContext context)
    {
        Context = context;
        DbSet = context.Set<TEntity>();
    }

    // Read Repository Methods
    public IQueryable<TEntity> GetAll(
        Expression<Func<TEntity, bool>> predicate, 
        bool tracking = true,
        params Expression<Func<TEntity, object>>[] includes)
    {
        return AddIncludes(DbSet.Where(predicate), tracking, includes);
    }

    public TEntity GetById(
        Expression<Func<TEntity, bool>> predicate,
        bool tracking = true,
        params Expression<Func<TEntity, object>>[]? includes)
    {
        var entity = AddIncludes(DbSet, tracking, includes).FirstOrDefault(predicate.Compile());

        if (entity == null) throw new
                EntityNotFoundException($"Entity of type {typeof(TEntity).Name.ToLower()} not found.");
        
        return entity;
    }

    // Write Repository Methods
    public async Task<TEntity> AddAsync(TEntity entity)
    {
        await DbSet.AddAsync(entity);
        await Context.SaveChangesAsync();

        return entity;
    }

    public async Task AddRangeAsync(ICollection<TEntity> items)
    {
        await DbSet.AddRangeAsync(items);
        await Context.SaveChangesAsync();
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        DbSet.Update(entity);
        await Context.SaveChangesAsync();

        return entity;
    }

    public async Task<TEntity> DeleteAsync(TEntity entity)
    {
        entity.IsDeleted = true;

        DbSet.Update(entity);
        await Context.SaveChangesAsync();

        return entity;
    }

    public async Task<TEntity> RecoverAsync(TEntity entity)
    {
        entity.IsDeleted = false;

        DbSet.Update(entity);
        await Context.SaveChangesAsync();

        return entity;
    }

    public async Task<TEntity> RemoveAsync(TEntity entity)
    {
        DbSet.Remove(entity);
        await Context.SaveChangesAsync();

        return entity;
    }

    public async Task RemoveAll(ICollection<TEntity> items)
    {
        DbSet.RemoveRange(items);
        await Context.SaveChangesAsync();
    }

    // Soft Deletion and IsActive Methods
    public async Task<TEntity> SoftDeleteAsync(TEntity entity)
    {
        entity.IsDeleted = true;
        DbSet.Update(entity);
        await Context.SaveChangesAsync();

        return entity;
    }

    public async Task<ICollection<TEntity>> SoftDeleteRangeAsync(ICollection<TEntity> items)
    {
        foreach (var item in items)
        {
            item.IsDeleted = true;
        }

        DbSet.UpdateRange(items);
        await Context.SaveChangesAsync();

        return items;
    }

    public async Task<TEntity> ActivateAsync(TEntity entity)
    {
        entity.IsActive = true;
        DbSet.Update(entity);
        await Context.SaveChangesAsync();

        return entity;
    }

    public async Task<TEntity> DeactivateAsync(TEntity entity)
    {
        entity.IsActive = false;
        DbSet.Update(entity);
        await Context.SaveChangesAsync();

        return entity;
    }

    public IQueryable<TEntity> GetAllActive(
        Expression<Func<TEntity, bool>> predicate,
        bool tracking = true,
        params Expression<Func<TEntity, object>>[] includes)
    {
        var query = DbSet.Where(x => x.IsActive && !x.IsDeleted).Where(predicate);
        return AddIncludes(query, tracking, includes);
    }

    public IQueryable<TEntity> GetAllDeleted(
        Expression<Func<TEntity, bool>> predicate,
        bool tracking = true,
        params Expression<Func<TEntity, object>>[] includes)
    {
        var query = DbSet.Where(x => x.IsDeleted).Where(predicate);
        return AddIncludes(query, tracking, includes);
    }

    // Additional Helper Methods
    private IQueryable<TEntity> AddIncludes(
        IQueryable<TEntity> query,
        bool tracking = true,
        params Expression<Func<TEntity, object>>[]? includes)
    {
        if (!tracking)
            query = query.AsNoTracking();

        return includes?.Aggregate(query, (current, include) => current.Include(include)) ?? query;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                Context.Dispose();
            }
            _disposed = true;
        }
    }
}
