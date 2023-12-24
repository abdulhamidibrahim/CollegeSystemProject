namespace FCISystem.DAL;

public interface IGenericRepo<T> 
    where T : class
{
    List<T> GetAll();
    T? GetById(long id);
    void Add(T entity);
    void Update(T entity);
    void Delete(T entity);
    void Delete(long id);
   
}