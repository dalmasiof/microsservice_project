using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IBaseRequest<T> where T : class
    {
        Task<T> Create(T entity);
        Task<T> Update(T entity);
        Task<bool> Delete(long number);
        Task<IEnumerable<T>> Get();
        Task<T> Get(long Id);
    }
}
