using Entities.Entities;
using PaymentOrderDB.Data.Context;
using PaymentOrderDB.Data.Repository.Interfaces;

namespace PaymentOrderDB.Data.Repository
{
    public class PORepository : IPORepository
    {
        private readonly PaymentOrderContext _context;

        public PORepository(PaymentOrderContext context)
        {
            _context = context;
        }
        public PaymentOrderData Create(PaymentOrderData entity)
        {
            _context.Add(entity);
            _context.SaveChanges();

            return entity;
        }

        public bool Delete(PaymentOrderData entity)
        {
            _context.PaymentOrders.Remove(entity);
            return SaveChanges();
        }

        public IEnumerable<PaymentOrderData> Get()
        {
            return _context.PaymentOrders;
        }

        public PaymentOrderData GetById(long Id)
        {
            return _context.PaymentOrders.Where(x => x.id == Id).FirstOrDefault();
        }

        public bool SaveChanges()
        {
            if (_context.SaveChanges() > 0)
                return true;

            return false;
        }

        public PaymentOrderData Update(PaymentOrderData entity)
        {
            _context.PaymentOrders.Update(entity);
            SaveChanges();
            return entity;
        }
    }
}
