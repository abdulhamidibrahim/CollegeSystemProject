using CollegeSystem.DAL.Context;

namespace FCISystem.DAL;

public class GenericRepo<T> : IGenericRepo<T> where T : class
{
    private readonly CollegeSystemDbContext _context;

    public GenericRepo(CollegeSystemDbContext context)
    {
        _context = context;
    }

    public List<T> GetAll()
    { 
        return _context.Set<T>().ToList();
    }

    public T? GetById(long id)
    {
        return _context.Set<T>().Find(id);        
    }

    public void Add(T entity)
    {
        _context.Set<T>().Add(entity);
              
    }

    public void Update(T entity)
    {
        _context.Set<T>().Update(entity);
        
    }

    public void Delete(T entity)
    {
        _context.Remove(entity);
        
    }

    public void Delete(long id)
    {
        var entity = _context.Set<T>().Find(id);
        
        if (entity == null) return;
        
        _context.Remove(entity);
       
    }
    
}