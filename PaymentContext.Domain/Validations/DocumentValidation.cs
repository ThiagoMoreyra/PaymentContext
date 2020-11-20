using FluentValidation;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Validations
{
    public class DocumentValidation : AbstractValidator<Document>
    {
        public DocumentValidation()
        {
            RuleFor(c => c.Number)
                .NotEmpty().WithMessage("The {PropertyName} field needs to be provided")
                .NotNull().WithMessage("The {PropertyName} field cannot be null")
                .Length(11, 11);

            RuleFor(c => c.Type)
                .NotNull().WithMessage("The {PropertyName} field cannot be null");
        }
    }
}