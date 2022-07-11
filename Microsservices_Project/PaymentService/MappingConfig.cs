using AutoMapper;
using Entities.Entities;
using PaymentService.ViewModel;

namespace PaymentService
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<PaymentVM, PaymentData>().ReverseMap();
        }
    }
}
