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
            var payload = JsonSerializer.Deserialize<IEnumerable<UserDTO>>(responseContent);
            return null;


            //var teste  = _httpReq.Get(_url);
            //return teste;
        }

        public Task<UserData> Get(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<UserData> Post(UserData userData)
        {
            throw new NotImplementedException();
        }

        public Task<UserData> Put(UserData userData)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
