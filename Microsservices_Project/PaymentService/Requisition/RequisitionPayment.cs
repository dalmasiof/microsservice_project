using Entities.Entities;
using PaymentService.Requisition.Interface;
using PaymentService.Requisition.MessageSender;
using System.Text.Json;

namespace PaymentService.Requisition
{
    public class RequisitionPayment : IRequisitionPayment
    {
        private static HttpClient _httpClient;
        private static HttpClient HttpClient => _httpClient ?? (_httpClient = new HttpClient());
        private static string url = "https://localhost:7150/PaymentDB";

        private readonly IMessageSender _messageSender;

        public RequisitionPayment(IMessageSender messageSender)
        {
            _messageSender = messageSender;
        }
        public async Task<PaymentData> Create(PaymentData entity)
        {
            //HttpResponseMessage response = await HttpClient.PostAsJsonAsync(url, entity);
            //var responseContent = response.Content.ReadAsStringAsync().Result;
            //var payload = JsonSerializer.Deserialize<PaymentData>(responseContent);
            //return payload;

            _messageSender.SendMessage(entity);
            return entity;
        }

        public async Task<bool> Delete(long Id)
        {
            HttpResponseMessage response = await HttpClient.DeleteAsync(url + "/" + Id);
            return response.IsSuccessStatusCode;
        }

        public async Task<IEnumerable<PaymentData>> Get()
        {
            HttpResponseMessage response = await HttpClient.GetAsync(url);
            var responseContent = response.Content.ReadAsStringAsync().Result;
            var payload = JsonSerializer.Deserialize<IEnumerable<PaymentData>>(responseContent);
            return payload;
        }

        public async Task<PaymentData> Get(long Id)
        {
            HttpResponseMessage response = await HttpClient.GetAsync(url + "/" + Id);
            if (response.IsSuccessStatusCode)
            {
                var responseContent = response.Content.ReadAsStringAsync().Result;
                var payload = JsonSerializer.Deserialize<PaymentData>(responseContent);
                return payload;
            }
            return null;
        }

        public async Task<PaymentData> Update(PaymentData entity)
        {
            HttpResponseMessage response = await HttpClient.PutAsJsonAsync(url, entity);
            var responseContent = response.Content.ReadAsStringAsync().Result;
            var payload = JsonSerializer.Deserialize<PaymentData>(responseContent);
            return payload;
        }
    }
}
