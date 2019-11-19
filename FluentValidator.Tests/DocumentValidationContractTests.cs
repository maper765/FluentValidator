using FluentValidator.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentValidator.Tests
{
    [TestClass]
    public class DocumentValidationContractTests
    {
        [TestMethod]
        [TestCategory("DocumentValidation")]
        public void IsCpf()
        { 
            var wrong = new ValidationContract()
                .Requires()
                .IsCpf("00000000000", "CPF", "Document is invalid")
                .IsCpf("000.000.000-00", "CPF", "Document is invalid");

            Assert.AreEqual(false, wrong.Valid);
            Assert.AreEqual(2, wrong.Notifications.Count);

            var right = new ValidationContract()
                .Requires()
                .IsCpf("05113388050", "CPF", "Some valid document")
                .IsCpf("051.133.880-50", "CPF", "Some valid document");

            Assert.AreEqual(true, right.Valid);
        }

        [TestMethod]
        [TestCategory("DocumentValidation")]
        public void IsCnpj()
        {
            var wrong = new ValidationContract()
                .Requires()
                .IsCnpj("00000000000000", "CNPJ", "Document is invalid")
                .IsCnpj("00.000.000/0000-00", "CNPJ", "Document is invalid");

            Assert.AreEqual(false, wrong.Valid);
            Assert.AreEqual(2, wrong.Notifications.Count);

            var right = new ValidationContract()
                .Requires()
                .IsCnpj("25736897000147", "CNPJ", "Some valid document")
                .IsCnpj("25.736.897/0001-47", "CNPJ", "Some valid document");

            Assert.AreEqual(true, right.Valid);
        }
    }
}
