namespace MovieShopCore.Contracts.Repositories;

public interface IRepository<T> where T : class
{
    T Insert(T entity);
    
    T Update(T entity);
    
    T DeleteById(int id);
    
    IEnumerable<T> GetAll();
    
    T GetById(int id);
}