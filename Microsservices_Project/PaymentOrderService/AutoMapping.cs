using AutoMapper;
using Entities.Entities;
using PaymentOrderService.ViewModels;

public class AutoMapping : Profile
{
    public AutoMapping()
    {
        CreateMap<PaymentOrderData, PoVm>().ReverseMap();
    }
}