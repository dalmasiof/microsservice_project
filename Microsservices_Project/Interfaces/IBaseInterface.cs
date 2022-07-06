using System;

public interface IBaseInterface <T> where T : class
{
    T Create(T entity);
    T Update(T entity);
    bool Delete(long number);
    Task<IEnumerable<T>> Get();
    T Get(long Id);
    bool SaveChanges();
}
