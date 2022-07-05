using PurchaseOrderService.Model;
using System.Text.Json;

namespace UserService.HttpMessageSender
{
    public class HttpMessageSender<T> : IHttpMessageSender<T> where T : class
    {
        private static HttpClient _httpClient;
        private static HttpClient HttpClient => _httpClient ?? (_httpClient = new HttpClient());
        private static string url = "localhost://";
        public Task<T> Delete()
        {
            throw new NotImplementedException();
        }

        public async Task<T> Get()
        {
            HttpResponseMessage response = await HttpClient.GetAsync(url);
            var responseContent = await response.Content.ReadAsStringAsync();
            var payload = JsonSerializer.Deserialize<T>(responseContent); 
            return payload;
            
        }

        public Task<T> Post()
        {
            throw new NotImplementedException();
        }

        public Task<T> Put()
        {
            throw new NotImplementedException();
        }
    }
}
