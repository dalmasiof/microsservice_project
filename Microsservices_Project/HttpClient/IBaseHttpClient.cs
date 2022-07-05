using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpRequisition
{
    public interface IBaseHttpClient <T> where T : class
    {

        public T Get(int Id,string path);
        public IEnumerable<T> Get( string path);
        public T Post(T obj, string path);
        public T Put(T obj, string path);
        public bool Delete(int Id, string path);

    }
}
