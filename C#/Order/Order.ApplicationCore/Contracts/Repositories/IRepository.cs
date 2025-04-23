namespace ApplicationCore.Contracts.Repositories;

public interface IRepository<T>  where T : class
{
    T Insert(T entity);
    
    T Update(T entity);
    
    T Delete(int id);
    
    T Get(int id);
    
    IEnumerable<T> GetAll();
}