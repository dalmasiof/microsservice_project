using System;

public interface IBaseRepository <T> where T : class
{
    T Create(T entity);
    T Update(T entity);
    bool Delete(T entity);
    IEnumerable<T> Get();
    T GetById(long Id);
    bool SaveChanges();
}
