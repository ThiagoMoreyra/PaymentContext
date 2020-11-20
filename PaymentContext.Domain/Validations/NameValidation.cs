using FluentValidation;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Validations
{
    public class NameValidation : AbstractValidator<Name>
    {
        public NameValidation()
        {
            RuleFor(c => c.FirstName)
                .NotEmpty().WithMessage("The {PropertyName} field needs to be provided")
                .Length(2, 100)
                .NotNull().WithMessage("The {PropertyName} field cannot be null");

            RuleFor(c => c.LastName)
                .NotEmpty().WithMessage("The {PropertyName} field needs to be provided")
                .Length(2, 100)
                .NotNull().WithMessage("The {PropertyName} field cannot be null");
        }
    }
}