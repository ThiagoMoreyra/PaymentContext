using PaymentContext.Domain.Enums;
using PaymentContext.Shared.Documents;
using PaymentContext.Shared.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Document : ValueObject
    {
        public Document(string number, EDocumentType type)
        {
            Number = number;
            Type = type;

            AddNotifications(new Contract()
                    .Requires()
                    .IsTrue(Validate(), "Document.Number", "Documento inválido"));
        }

        public string Number { get; set; }
        public EDocumentType Type { get; set; }

        private bool Validate()
        {
            if ((Type == EDocumentType.CNPJ) && (CnpjValidacao.Validar(Number)))
                return true;

            if ((Type == EDocumentType.CPF) && (CpfValidacao.Validar(Number)))
                return true;

            return false;
        }
    }
}