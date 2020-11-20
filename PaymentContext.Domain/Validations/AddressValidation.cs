using FluentValidation;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Validations
{
    public class AddressValidation : AbstractValidator<Address>
    {
        public AddressValidation()
        {
            RuleFor(c => c.City)
                .NotEmpty().WithMessage("The {PropertyName} field needs to be provided")
                .NotNull().WithMessage("The {PropertyName} field cannot be null");

            RuleFor(c => c.Neighborhood)
                .NotEmpty().WithMessage("The {PropertyName} field needs to be provided")
                .NotNull().WithMessage("The {PropertyName} field cannot be null");

            RuleFor(c => c.Number)
                .NotEmpty().WithMessage("The {PropertyName} field needs to be provided")
                .NotNull().WithMessage("The {PropertyName} field cannot be null");

            RuleFor(c => c.Street)
                .NotEmpty().WithMessage("The {PropertyName} field needs to be provided")
                .NotNull().WithMessage("The {PropertyName} field cannot be null");

            RuleFor(c => c.State)
                .NotEmpty().WithMessage("The {PropertyName} field needs to be provided")
                .NotNull().WithMessage("The {PropertyName} field cannot be null");

            RuleFor(c => c.Country)
                .NotEmpty().WithMessage("The {PropertyName} field needs to be provided")
                .NotNull().WithMessage("The {PropertyName} field cannot be null");

            RuleFor(c => c.ZipCode)
                .NotEmpty().WithMessage("The {PropertyName} field needs to be provided")
                .NotNull().WithMessage("The {PropertyName} field cannot be null");
        }
    }
}