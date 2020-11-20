using System;
using PaymentContext.Domain.Enums;
using PaymentContext.Shared.Commands;
using PaymentContext.Shared.Notify;
using PaymentContext.Shared.Validations;

namespace PaymentContext.Domain.Command
{
    public class CreateBoletoSubscriptionCommand : Notifiable, ICommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BarCode { get; set; }
        public string BoletoCode { get; set; }
        public string BoletoNumber { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public DateTime PaidDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public decimal Total { get; set; }
        public decimal TotalPaid { get; set; }
        public string PayerDocument { get; set; }
        public string Payer { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public EDocumentType PayerDocumentType { get; set; }
        public string Owner { get; set; }
        public string PayerEmail { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                    .Requires()
                    .HasMinLen(FirstName, 3, "Name.FirstName", "Nome deve conter pelo menos 3 caracteres")
                    .HasMinLen(LastName, 3, "Name.LastName", "Nome deve conter pelo menos 3 caracteres")
                    .HasMaxLen(FirstName, 40, "Name.FirstName", "Nome deve conter pelo menos 3 caracteres"));
        }
    }
}