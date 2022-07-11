using Entities.Entities;
using PaymentDB.Data.Context;

namespace PaymentDB.Data.Repository
{
    public class PaymentRepository : IPaymentRepository
    {

        private readonly PaymentCOntext _paymentCOntext;
        public PaymentRepository(PaymentCOntext paymentCOntext)
        {
            _paymentCOntext = paymentCOntext;
        }
        public PaymentData Create(PaymentData entity)
        {
            _paymentCOntext.paymentDatas.Add(entity);
            SaveChanges();
            return entity;
        }

        public bool Delete(PaymentData entity)
        {
            _paymentCOntext.paymentDatas.Remove(entity);
            return SaveChanges();
        }

        public IEnumerable<PaymentData> Get()
        {
            return _paymentCOntext.paymentDatas;
        }

        public PaymentData GetById(long Id)
        {
            return _paymentCOntext.paymentDatas.Where(x => x.id == Id).FirstOrDefault();
        }

        public bool SaveChanges()
        {
            if(_paymentCOntext.SaveChanges() > 0)
                return true;
            return false;
        }

        public PaymentData Update(PaymentData entity)
        {
            _paymentCOntext.paymentDatas.Update(entity);
            SaveChanges();
            return entity;
        }
    }
}
