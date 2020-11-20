using System;
using System.Reflection.Metadata;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.Entities
{
    [TestClass]
    public class StudentTests
    {
        private readonly Name _name;
        private readonly Domain.ValueObjects.Document _document;
        private readonly Email _email;
        private readonly Address _address;
        private readonly Student _student;
        private readonly Subscription _subscription;
        public StudentTests()
        {
            _name = new Name("Bruce", "Wayne");
            _document = new Domain.ValueObjects.Document("58941728029", EDocumentType.CPF);
            _email = new Email("teste@gmail.com");
            _address = new Address("Rua 1", "1234", "Bairro Teste", "Rio", "RJ", "BR", "23333333");
            _student = new Student(_name, _document, _email);
            _subscription = new Subscription(null);
        }

        [TestMethod]
        public void ShoudReturnErrorWhenHadActiveSubscription()
        {
            var payment = new PayPalPayment("5555555", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, _address, _document, "NCorp", _email);
            _subscription.AddPayment(payment);
            _student.AddSubscription(_subscription);
            _student.AddSubscription(_subscription);

            Assert.IsTrue(_student.Invalid);
        }

        [TestMethod]
        public void ShoudReturnErrorWhenHadSubscriptionHasNoPayment()
        {
            var name = new Name("Bruce", "Wayne");
            var document = new Domain.ValueObjects.Document("58941728029", EDocumentType.CPF);
            var email = new Email("teste@gmail.com");
            var student = new Student(name, document, email);

            Assert.Fail();
        }

        [TestMethod]
        public void ShoudReturnErrorWhenHadNoActiveSubscription()
        {
            var payment = new PayPalPayment("5555555", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, _address, _document, "NCorp", _email);
            _subscription.AddPayment(payment);
            _student.AddSubscription(_subscription);
            _student.AddSubscription(_subscription);

            Assert.IsTrue(_student.Valid);
        }

        [TestMethod]
        public void ShoudReturnErrorWhenSubscriptionHasNoPayment()
        {
            _student.AddSubscription(_subscription);
            Assert.IsTrue(_student.Invalid);
        }

        [TestMethod]
        public void ShoudReturnSucessWhenAddSubscription()
        {
            var payment = new PayPalPayment("5555555", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, _address, _document, "NCorp", _email);
            _subscription.AddPayment(payment);
            _student.AddSubscription(_subscription);

            Assert.IsTrue(_student.Valid);
        }

    }
}