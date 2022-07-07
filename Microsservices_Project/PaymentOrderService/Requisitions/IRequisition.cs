using Entities.Entities;
using Interfaces;

namespace PaymentOrderService.Requisitions
{
    public interface IRequisition
    {
        public Task<PaymentOrderData> Get(long Id);
        public Task<PaymentOrderData> Post(PaymentOrderData PaymentOrderData);
        public Task<PaymentOrderData> Put(PaymentOrderData PaymentOrderData);
        public Task<bool> Delete(long id);
        public Task<IEnumerable<PaymentOrderData>> Get();
    }
}
