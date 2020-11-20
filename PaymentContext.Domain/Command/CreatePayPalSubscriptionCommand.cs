using System;
using PaymentContext.Domain.Enums;
using PaymentContext.Shared.Commands;
using PaymentContext.Shared.Notify;

namespace PaymentContext.Domain.Command
{
    public class CreatePayPalSubscriptionCommand : Notifiable, ICommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TransactionCode { get; set; }
        public DateTime PaidDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public decimal Total { get; set; }
        public decimal TotalPaid { get; set; }
        public string PayerDocument { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string Street { get; private set; }
        public string Number { get; private set; }
        public string Neighborhood { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }
        public string ZipCode { get; private set; }
        public EDocumentType PayerDocumentType { get; set; }
        public string Owner { get; set; }
        public string PayerEmail { get; set; }

        public void Validate()
        {
            throw new NotImplementedException();
        }
    }
}