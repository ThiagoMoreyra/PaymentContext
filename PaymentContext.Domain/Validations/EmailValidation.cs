using FluentValidation;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Validations
{
    public class EmailValidation : AbstractValidator<Email>
    {
        public EmailValidation()
        {
            RuleFor(c => c.Address)
                .NotEmpty().WithMessage("The {PropertyName} field needs to be provided")
                .Length(2, 100)
                .NotNull().WithMessage("The {PropertyName} field cannot be null")
                .EmailAddress().WithMessage("Invalid {PropertyName}");
        }
    }
}