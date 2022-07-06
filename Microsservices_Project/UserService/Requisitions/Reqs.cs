using HttpRequisition;
using UserService.Model;
using System.Text.Json;

namespace UserService.Requisitions
{
    public class Reqs : IReqs
    {
        //private readonly IBaseHttpClient<UserData> _httpReq;
        //private readonly string _url;

        private static HttpClient _httpClient;
        private static HttpClient HttpClient => _httpClient ?? (_httpClient = new HttpClient());
        private static string url = "https://localhost:7172/UserDataBD";


        //public HttpMessageSender(IBaseHttpClient<UserData> httpReq)
        //{
        //    _httpReq = httpReq;
        //    _url = "teste";
            
        //}

        public async Task<IEnumerable<UserData>> Get()
        {
            HttpResponseMessage response = await HttpClient.GetAsync(url);
            var responseContent =  response.Content.ReadAsStringAsync().Result;
            var payload = JsonSerializer.Deserialize<IEnumerable<UserData>>(responseContent);
            return payload;
        }

        public async Task<UserData> Get(long Id)
        {
            HttpResponseMessage response = await HttpClient.GetAsync(url + "/" + Id);
            var responseContent = response.Content.ReadAsStringAsync().Result;
            var payload = JsonSerializer.Deserialize<UserData>(responseContent);
            return payload;
        }

        public async Task<UserData> Post(UserData userData)
        {
            HttpResponseMessage response = await HttpClient.PostAsJsonAsync(url,userData);
            var responseContent = response.Content.ReadAsStringAsync().Result;
            var payload = JsonSerializer.Deserialize<UserData>(responseContent);
            return payload;
        }

        public async Task<UserData> Put(UserData userData)
        {
            HttpResponseMessage response = await HttpClient.PutAsJsonAsync(url, userData);
            var responseContent = response.Content.ReadAsStringAsync().Result;
            var payload = JsonSerializer.Deserialize<UserData>(responseContent);
            return payload;
        }

        public async Task<bool> Delete(long Id)
        {
            HttpResponseMessage response = await HttpClient.DeleteAsync(url+"/"+Id);
            return response.IsSuccessStatusCode;
        }
    }
}
