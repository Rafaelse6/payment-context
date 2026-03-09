using PaymentContext.Domain.Entities;

namespace PaymentContext.Tests;

[TestClass]
public sealed class StudentTests
{
    [TestMethod]
    public void AdicionarAssinatura()
    {
        var subscription = new Subscription(null);
        var student = new Student("André", "Baltieri", "12345678912", "hello@balta.io");
        student.AddSubscription(subscription);
    }
}

//26