using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Handlers;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Tests.Mocks;

namespace PaymentContext.Tests
{
    [TestClass]
    public class SubscriptionHandlerTests
    {
        [TestMethod]
        public void ShouldReturnErrorWhenDocumentExists()
        {
            var handler = new SubscriptionHandler(
                new FakeStudentRepository(),
                new FakeEmailService()
            );

            var command = new CreateBoletoSubscriptionCommand
            {
                FirstName = "Bruce",
                LastName = "Wayne",
                Document = "99999999999", 
                Email = "bruce@wayne.com",

                BarCode = "123456789",
                BoletoNumber = "123456789",

                PaymentNumber = "123456",
                PaidDate = DateTime.Now,
                ExpireDate = DateTime.Now.AddMonths(1),
                Total = 60,
                TotalPaid = 60,

                Payer = "Bruce Wayne",

                PayerDocument = new Document("12345678911", EDocumentType.CPF),
                PayerDocumentType = EDocumentType.CPF,

                PayerEmail = "bruce@wayne.com",

                Street = "Rua Gotham",
                Number = "100",
                Neighborhood = "Centro",
                City = "Gotham",
                State = "NY",
                Country = "USA",
                ZipCode = "12345678"
            };

            handler.Handle(command);

            Assert.IsFalse(handler.Valid);
        }
    }
}