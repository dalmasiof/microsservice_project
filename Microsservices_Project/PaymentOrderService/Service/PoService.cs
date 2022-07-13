using AutoMapper;
using Entities.Entities;
using FluentValidation;
using PaymentOrderService.Requisitions;
using PaymentOrderService.ViewModels;

namespace PaymentOrderService.Service
{
    public class PoService : IPOService
    {
        private readonly IPoRequisition _reqs;
        private readonly IMapper _map;


        public PoService(IPoRequisition ireqs, IMapper mapper)
        {
            _reqs = ireqs;
            _map = mapper;
        }

        public async Task<PoVm> Create(PoVm entity)
        {
            Validate(entity);
            var entityoCreate = _map.Map<PaymentOrderData>(entity);
            var entityVMCreated = _map.Map<PoVm>(await _reqs.Create(entityoCreate));
            return entityVMCreated;

        }

        public async Task<bool> Delete(long number)
        {
            return (await _reqs.Delete(number));
        }

        public async Task<IEnumerable<PoVm>> Get()
        {
            var userDto = _map.Map<IEnumerable<PoVm>>(await _reqs.Get());
            return userDto;
        }

        public async Task<PoVm> Get(long Id)
        {
            var userToGet = _map.Map<PoVm>(await _reqs.Get(Id));
            return userToGet;
        }

        public async Task<PoVm> Update(PoVm entity)
        {
            Validate(entity);
            var userToUpdate = _map.Map<PaymentOrderData>(entity);
            var userTdUpdated = _map.Map<PoVm>(await _reqs.Update(userToUpdate));
            return userTdUpdated;
        }

        public void Validate(PoVm obj)
        {
            PoValidator validationRules = new PoValidator();
            validationRules.ValidateAndThrow(obj);
        }
    }
}
