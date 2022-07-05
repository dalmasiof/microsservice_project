using System;

public interface IBaseInterface <T> where T : class
{
    T Create(T entity);
    T Update(T entity);
    T Delete(T entity);
    Task<IEnumerable<T>> Get();
    T Get(int Id);
    bool SaveChanges();
}
