using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HttpRequisition
{
    public class HttpRequisition<T> : IBaseHttpClient<T> where T : class
    {
        private readonly HttpClient _httpClient;
        public readonly string _url;

        public HttpRequisition(HttpClient httpClient, string url)
        {
            _httpClient = httpClient;
        }

        bool IBaseHttpClient<T>.Delete(int Id, string path)
        {
            return (_httpClient.DeleteAsync(_url + "/" + Id).IsCompletedSuccessfully);
            
        }

        T IBaseHttpClient<T>.Get(int Id, string path)
        {
            var entity = JsonSerializer.Deserialize<T>(_httpClient.GetAsync(_url).Result.ToString());
            return entity;
        }

        IEnumerable<T> IBaseHttpClient<T>.Get(string path)
        {
            var entities = JsonSerializer.Deserialize<IEnumerable<T>>(_httpClient.GetAsync(_url).Result.ToString());
            return entities;
        }

        T IBaseHttpClient<T>.Post(T obj, string path)
        {
            throw new NotImplementedException();
        }

        T IBaseHttpClient<T>.Put(T obj, string path)
        {
            throw new NotImplementedException();
        }
    }
}
