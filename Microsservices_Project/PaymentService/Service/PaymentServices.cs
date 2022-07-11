using AutoMapper;
using Entities.Entities;
using FluentValidation;
using PaymentService.Requisition.Interface;
using PaymentService.Service.Interfaces;
using PaymentService.Service.Validator;
using PaymentService.ViewModel;

namespace PaymentService.Service
{
    public class PaymentServices : IPaymentService
    {
        private readonly IRequisitionPayment _requisition;
        private readonly IMapper _mapper;

        public PaymentServices(IRequisitionPayment requisitionPayment,IMapper mapper)
        {
            _requisition = requisitionPayment;
            _mapper = mapper;
        }
      
        public async Task<PaymentVM> Create(PaymentVM entity)
        {
            Validate(entity);
            var entityToCreate = _mapper.Map<PaymentVM, PaymentData>(entity);
            var entityCreated = _mapper.Map<PaymentData, PaymentVM>(await _requisition.Create(entityToCreate));
            return entityCreated;
        }

        public async Task<bool> Delete(long number)
        {
            return await _requisition.Delete(number);
        }

        public async Task<IEnumerable<PaymentVM>> Get()
        {
            var entities = _mapper.Map<IEnumerable<PaymentData>, IEnumerable<PaymentVM>>(await _requisition.Get());
            return entities;
        }

        public async Task<PaymentVM> Get(long Id)
        {
            var entity = _mapper.Map<PaymentData, PaymentVM>(await _requisition.Get(Id));
            return entity;
        }

        public async Task<PaymentVM> Update(PaymentVM entity)
        {
            Validate(entity);
            var entityToUpdate = _mapper.Map<PaymentVM, PaymentData>(entity);
            var entityUpdated = _mapper.Map<PaymentData, PaymentVM>(await _requisition.Update(entityToUpdate));
            return entityUpdated;
        }

        public void Validate(PaymentVM entity)
        {
            PaymentValidator validationRules = new PaymentValidator();
            validationRules.ValidateAndThrow(entity);
        }
    }
}
