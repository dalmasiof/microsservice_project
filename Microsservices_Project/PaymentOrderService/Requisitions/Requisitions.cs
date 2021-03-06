using Entities.Entities;
using PaymentOrderService.ViewModels;
using System.Text.Json;

namespace PaymentOrderService.Requisitions
{
    public class Requisitions : IPoRequisition
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
            HttpResponseMessage response = await HttpClient.GetAsync(url+"/"+Id);
            if (response.IsSuccessStatusCode)
            {
                var responseContent = response.Content.ReadAsStringAsync().Result;
                var payload = JsonSerializer.Deserialize<PaymentOrderData>(responseContent);
                return payload;
            }
            return null;

        }

        public async Task<PaymentOrderData> Create(PaymentOrderData PaymentOrderData)
        {
            HttpResponseMessage response = await HttpClient.PostAsJsonAsync(url, PaymentOrderData);
            var responseContent = response.Content.ReadAsStringAsync().Result;
            var payload = JsonSerializer.Deserialize<PaymentOrderData>(responseContent);
            return payload;
        }

        public async Task<PaymentOrderData> Update(PaymentOrderData PaymentOrderData)
        {
            HttpResponseMessage response = await HttpClient.PutAsJsonAsync(url, PaymentOrderData);
            var responseContent = response.Content.ReadAsStringAsync().Result;
            var payload = JsonSerializer.Deserialize<PaymentOrderData>(responseContent);
            return payload;
        }
    }
}
