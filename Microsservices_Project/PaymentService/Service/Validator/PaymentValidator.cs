using FluentValidation;
using PaymentService.ViewModel;

namespace PaymentService.Service.Validator
{
    public class PaymentValidator :AbstractValidator<PaymentVM>
    {
        public PaymentValidator()
        {
            RuleFor(x => x.id)
                .NotNull();

            RuleFor(x => x.idPaymentOrder)
                .GreaterThanOrEqualTo(0)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.idUser)
                .GreaterThanOrEqualTo(0)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.value)
                .GreaterThanOrEqualTo(0)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.paymentDate)
                .LessThanOrEqualTo(DateTime.Now)
                .NotEmpty()
                .NotNull();
        }
    }
}
