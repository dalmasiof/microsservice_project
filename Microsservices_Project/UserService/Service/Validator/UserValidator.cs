using FluentValidation;
using UserService.Model;

namespace UserService.Service.Validator
{
    public class UserValidator : AbstractValidator<UserDTO>
    {
        public UserValidator()
        {
            RuleFor(x => x.Email)
                .EmailAddress().WithMessage("Invalid Email")
                .NotEmpty().WithMessage("Must have Email")
                .NotEmpty().WithMessage("Must have Email")
                .MaximumLength(256).WithMessage("Must have less than 256 characters");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Must have LastName")
                .NotEmpty().WithMessage("Must have LastName")
                .MaximumLength(500).WithMessage("Must have less than 500 characters");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Must have Name")
                .NotEmpty().WithMessage("Must have Name")
                .MaximumLength(500).WithMessage("Must have less than 500 characters");

            RuleFor(x => x.BirthDate)
                .NotEmpty().WithMessage("Must have BirthDate")
                .NotEmpty().WithMessage("Must have BirthDate")
                .LessThan(DateTime.Now).WithMessage("Must be lower then Date now");
                

        }
    }
}
