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
            .Equal(0).WithMessage("PaymentOrder always must be created with 0 value paied");

    }
}
