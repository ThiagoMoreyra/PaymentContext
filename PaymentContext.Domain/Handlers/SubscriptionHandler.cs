using System;
using PaymentContext.Domain.Command;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Repositories;
using PaymentContext.Domain.Services;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Commands;
using PaymentContext.Shared.Handlers;
using PaymentContext.Shared.Notify;

namespace PaymentContext.Domain.Handlers
{
    public class SubscriptionHandler :
                Notifiable,
                IHandler<CreateBoletoSubscriptionCommand>,
                IHandler<CreatePayPalSubscriptionCommand>
    {
        private readonly IStudentRepository _repository;
        private readonly IEmailService _emailService;

        public SubscriptionHandler(IStudentRepository repository, IEmailService emailService)
        {
            _repository = repository;
            _emailService = emailService;
        }
        public ICommandResult Handle(CreateBoletoSubscriptionCommand command)
        {
            command.Validate();
            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Não foi possível realizar sua assinatura.");
            }

            if (_repository.DocumentExists(command.Document))
                AddNotification("Document", "Este cpf já está em uso.");

            if (_repository.DocumentExists(command.Email))
                AddNotification("Email", "Este e-mail já está em uso.");


            var name = new Name("Bruce", "Wayne");
            var document = new Domain.ValueObjects.Document("58941728029", EDocumentType.CPF);
            var email = new Email("teste@gmail.com");
            var address = new Address(command.Street, command.Number, command.Neighborhood, command.City, command.State, command.Country, command.ZipCode);

            var student = new Student(name, document, email);
            var subscription = new Subscription(DateTime.Now.AddMonths(1));
            var payment = new BoletoPayment(command.BarCode, command.BoletoNumber, command.Number, command.PaidDate, command.ExpireDate, command.Total, command.TotalPaid,
            address, new Document(command.PayerDocument, command.PayerDocumentType), command.Owner, email);

            subscription.AddPayment(payment);
            student.AddSubscription(subscription);

            AddNotifications(name, document, email, address, student, subscription, payment);

            _repository.CreateSubscription(student);

            _emailService.Send(student.Name.ToString(), student.Email.Address, "Bem vindo", "Sua assinatura foi criada.");

            return new CommandResult(true, "Assinatura realizada com sucesso");
        }

        public ICommandResult Handle(CreatePayPalSubscriptionCommand command)
        {
            if (_repository.DocumentExists(command.Document))
                AddNotification("Document", "Este cpf já está em uso.");

            if (_repository.DocumentExists(command.Email))
                AddNotification("Email", "Este e-mail já está em uso.");


            var name = new Name("Bruce", "Wayne");
            var document = new Domain.ValueObjects.Document("58941728029", EDocumentType.CPF);
            var email = new Email("teste@gmail.com");
            var address = new Address(command.Street, command.Number, command.Neighborhood, command.City, command.State, command.Country, command.ZipCode);

            var student = new Student(name, document, email);
            var subscription = new Subscription(DateTime.Now.AddMonths(1));
            var payment = new PayPalPayment(command.TransactionCode, command.PaidDate, command.ExpireDate, command.Total, command.TotalPaid,
            address, new Document(command.PayerDocument, command.PayerDocumentType), command.Owner, email);

            subscription.AddPayment(payment);
            student.AddSubscription(subscription);

            AddNotifications(name, document, email, address, student, subscription, payment);

            if (Invalid)
                return new CommandResult(false, "Não foi possível realizar a sua assinatura");

            _repository.CreateSubscription(student);

            _emailService.Send(student.Name.ToString(), student.Email.Address, "Bem vindo", "Sua assinatura foi criada.");

            return new CommandResult(true, "Assinatura realizada com sucesso");
        }
    }
}