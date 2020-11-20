using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Command;
using PaymentContext.Domain.Handlers;
using PaymentContext.Tests.Mocks;

namespace PaymentContext.Tests.Handlers
{
    [TestClass]
    public class SubscriptionHandlerTests
    {
        [TestMethod]
        public void ShouldReturnErrorWhenDocumentExist()
        {
            var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailService());
            var command = new CreateBoletoSubscriptionCommand();
            command.FirstName = "Myke";
            command.LastName = "Tyson";
            command.BarCode = "99999999999";
            command.BoletoCode = "123456";
            command.BoletoNumber = "123456";
            command.Document = "123456";
            command.Email = "teste@gmail.com";
            command.PaidDate = DateTime.Now;
            command.ExpireDate = DateTime.Now;
            command.Total = 60;
            command.TotalPaid = 60;
            command.PayerDocument = "1234567891011";
            command.Payer = "Tyson Corp";
            command.Street = "Rua teste";
            command.Number = "123456";
            command.Neighborhood = "Teste";
            command.City = "RJ";
            command.State = "RJ";
            command.Country = "BR";
            command.ZipCode = "111111";
            command.PayerDocumentType = Domain.Enums.EDocumentType.CPF;
            command.Owner = "Tyson Inc.";
            command.PayerEmail = "teste@gmail.com";

            handler.Handle(command);
            Assert.AreEqual(false, handler.Valid);
        }
    }
}