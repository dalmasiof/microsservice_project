using FluentValidation;
using PaymentOrderService.ViewModels;
using System;

public class PoValidator : AbstractValidator<PoVm>
{
    public PoValidator()
    {
        RuleFor(x => x.userId)
            .GreaterThan(0)
            .NotEmpty()
            .NotNull();


        RuleFor(x => x.total)
            .NotEmpty()
            .NotNull();

        RuleFor(x => x.totalToPay)
            .NotEmpty()
            .NotNull();

        RuleFor(x => x.shippingCost)
            .NotEmpty()
            .NotNull();

        RuleFor(x => x.totalPayed)
            .NotEmpty()
            .NotNull();

    }
}
