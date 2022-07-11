using Entities.Entities;
using PaymentOrderService.ViewModels;
using System.Text.Json;

namespace PaymentOrderService.Requisitions
{
    public class Requisitions : IRequisition
    {

        private static HttpClient _httpClient;
        private static HttpClient HttpClient => _httpClient ?? (_httpClient = new HttpClient());
        private static string url = "https://localhost:7174/PoDb";

        public async Task<bool> Delete(long number)
        {
            HttpResponseMessage response = await HttpClient.DeleteAsync(url+"/"+number);
            return response.IsSuccessStatusCode;
        }

        public async Task<IEnumerable<PaymentOrderData>> Get()
        {
            HttpResponseMessage response = await HttpClient.GetAsync(url);
            var responseContent = response.Content.ReadAsStringAsync().Result;
            var payload = JsonSerializer.Deserialize<IEnumerable<PaymentOrderData>>(responseContent);
            return payload;
        }

        public async Task<PaymentOrderData> Get(long Id)
        {
            HttpResponseMessage response = await HttpClient.GetAsync(url);
            var responseContent = response.Content.ReadAsStringAsync().Result;
            var payload = JsonSerializer.Deserialize<IEnumerable<PaymentOrderData>>(responseContent);
            return payload.FirstOrDefault();
        }

        public async Task<PaymentOrderData> Post(PaymentOrderData PaymentOrderData)
        {
            HttpResponseMessage response = await HttpClient.PostAsJsonAsync(url, PaymentOrderData);
            var responseContent = response.Content.ReadAsStringAsync().Result;
            var payload = JsonSerializer.Deserialize<PaymentOrderData>(responseContent);
            return payload;
        }

        public async Task<PaymentOrderData> Put(PaymentOrderData PaymentOrderData)
        {
            HttpResponseMessage response = await HttpClient.PutAsJsonAsync(url, PaymentOrderData);
            var responseContent = response.Content.ReadAsStringAsync().Result;
            var payload = JsonSerializer.Deserialize<PaymentOrderData>(responseContent);
            return payload;
        }
    }
}
