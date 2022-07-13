using HttpRequisition;
using UserService.Model;
using System.Text.Json;

namespace UserService.Requisitions
{
    public class Reqs : IUserRequest
    {

        private static HttpClient _httpClient;
        private static HttpClient HttpClient => _httpClient ?? (_httpClient = new HttpClient());
        private static string url = "https://localhost:7172/UserDataBD";

        public async Task<IEnumerable<UserData>> Get()
        {
            HttpResponseMessage response = await HttpClient.GetAsync(url);
            var responseContent = response.Content.ReadAsStringAsync().Result;
            var payload = JsonSerializer.Deserialize<IEnumerable<UserData>>(responseContent);
            return payload;
        }

        public async Task<UserData> Get(long Id)
        {
            HttpResponseMessage response = await HttpClient.GetAsync(url + "/" + Id);
            if (response.IsSuccessStatusCode)
            {
                var responseContent = response.Content.ReadAsStringAsync().Result;
                var payload = JsonSerializer.Deserialize<UserData>(responseContent);
                return payload;
            }

            return null;
        }

        public async Task<UserData> Create(UserData userData)
        {
            HttpResponseMessage response = await HttpClient.PostAsJsonAsync(url, userData);
            var responseContent = response.Content.ReadAsStringAsync().Result;
            var payload = JsonSerializer.Deserialize<UserData>(responseContent);
            return payload;
        }

        public async Task<UserData> Update(UserData userData)
        {
            HttpResponseMessage response = await HttpClient.PutAsJsonAsync(url, userData);
            var responseContent = response.Content.ReadAsStringAsync().Result;
            var payload = JsonSerializer.Deserialize<UserData>(responseContent);
            return payload;
        }

        public async Task<bool> Delete(long Id)
        {
            HttpResponseMessage response = await HttpClient.DeleteAsync(url + "/" + Id);
            return response.IsSuccessStatusCode;
        }
    }
}
