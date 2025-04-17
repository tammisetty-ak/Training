using MovieShopCore.Contracts.Repositories;
using MovieShopInfrastructure.Data;

namespace MovieShopInfrastructure.Repositories;

public class BaseRepository<T> : IRepository<T> where T: class
{

    protected readonly MovieShopDbContext _dbContext;
    public BaseRepository(MovieShopDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public T Insert(T entity)
    {
        _dbContext.Set<T>().Add(entity);
        _dbContext.SaveChanges();
        return entity;
    }

    public T Update(T entity)
    {
        _dbContext.Set<T>().Update(entity);
        _dbContext.SaveChanges();
        return entity;
    }

    public T DeleteById(int id)
    {
        var entity = _dbContext.Set<T>().Find(id);
        if (entity == null)
            return null;
        _dbContext.Set<T>().Remove(entity);
        _dbContext.SaveChanges();
        return entity;
    }

    public IEnumerable<T> GetAll()
    {
        return _dbContext.Set<T>().ToList();
    }

    public T GetById(int id)
    {
        var entity = _dbContext.Set<T>().Find(id);
        if (entity == null)
            return null;
        return entity;
    }
}