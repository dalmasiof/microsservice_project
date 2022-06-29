using System;

public interface IBaseRepository <T> where T : class
{
    T Create(T entity);
    T Update(T entity);
    T Delete(T entity);
    IEnumerable<T> Get(T entity);
    bool SaveChanges();
}
