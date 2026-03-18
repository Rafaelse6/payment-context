using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests;

[TestClass]
public class DocumentTests
{
    [TestMethod]
    public void ShouldReturnErrorWhenCNPJIsInvalid()
    {
        var doc = new Document("123", type: EDocumentType.CNPJ);
        Assert.IsTrue(doc.Invalid);
    }

    [TestMethod]
    public void ShouldReturnSuccessWhenCNPJIsValid()
    {
        var doc = new Document("19734730000144", type: EDocumentType.CNPJ);
        Assert.IsTrue(doc.Valid);
    }

    [TestMethod]
    public void ShouldReturnErrorWhenCPFIsInvalid()
    {
        var doc = new Document("123", type: EDocumentType.CPF);
        Assert.IsTrue(doc.Invalid);
    }

    [TestMethod]
    public void ShouldReturnSuccessWhenCPFIsValid()
    {
        var doc = new Document("09013476040", type: EDocumentType.CPF);
        Assert.IsTrue(doc.Valid);
    }
}

