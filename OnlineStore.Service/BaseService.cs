using System.Data.Entity;
using System.Linq.Expressions;
using OnlineStore.DataAccess;
using OnlineStore.Entities.Entities;
using OnlineStore.Service.Models;

namespace OnlineStore.Service;

public abstract class BaseService<TEntity> : BaseService<TEntity, int>
    where TEntity : class, IBaseEntity<int>
{
    protected BaseService(StoreDataContext dataContext) : base(dataContext)
    {
    }
}

public abstract class BaseService<TEntity, TKey>
    where TEntity : class, IBaseEntity<TKey>
{
    private readonly StoreDataContext _dataContext;
    private readonly DbSet<TEntity> _dbSet;

    protected BaseService(StoreDataContext dataContext)
    {
        _dataContext = dataContext;
        _dbSet = dataContext.Set<TEntity>();
    }

    public Task<List<TEntity>> GetAllAsync(
        Expression<Func<TEntity, bool>> expression,
        bool noTracking = false)
    {
        var query = _dbSet;

        if (noTracking)
        {
            query.AsNoTracking();
        }

        return query.Where(expression).ToListAsync();
    }

    public Task<List<TEntity>> GetPagedAsync(
        Expression<Func<TEntity, bool>> expression,
        Pagination pagination,
        bool noTracking = false)
    {
        var query = _dbSet.Where(expression);

        if (noTracking)
        {
            query.AsNoTracking();
        }

        query = pagination.SortOrder == SortOrder.Ascending ?
            query.OrderBy(x => x.Id) :
            query.OrderByDescending(x => x.Id);


        return query.Skip(pagination.PageSize * pagination.PageIndex)
            .Take(pagination.PageSize)
            .ToListAsync();
    }

    public Task<TEntity> GetByIdAsync(TKey key, bool noTracking = false)
    {
        var query = _dbSet;

        if (noTracking)
        {
            query.AsNoTracking();
        }

        return query.SingleOrDefaultAsync(x => x.Id!.Equals(key));
    }

    public void Add(TEntity entity)
    {
        _dbSet.Add(entity);
    }


    public void Edit(TEntity entity)
    {
        _dbSet.Attach(entity);
        _dataContext.Entry(entity).State = EntityState.Modified;
    }

    public void Delete(TEntity entity)
    {
        if (entity is ISoftDeleteEnabledBase)
        {
            ((ISoftDeleteEnabledBase)entity).IsDeleted = true;
            _dataContext.Entry(entity).State = EntityState.Modified;
        }
        else
        {
            _dbSet.Remove(entity);
        }
    }

    public void Delete(TKey key)
    {
        var entity = GetByIdAsync(key).Result;
        Delete(entity);
    }

    public int SaveChanges()
    {
        return _dataContext.SaveChanges();
    }

    public Task SaveChangesAsync()
    {
        return _dataContext.SaveChangesAsync();
    }
}