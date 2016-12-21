using Microsoft.VisualStudio.TestTools.UnitTesting;
using Speedledger.AccountService.Models;

namespace Speedledger.AccountService.Accounting.Tests
{
    [TestClass()]
    public class NotSyntheticAccountConstraintTests
    {
        [TestMethod]
        public void VerifyNotSyntheticAccount()
        {
            // arrange
            var bankAccount = new BankAccount { Synthetic = false };
            var notSythenticAccountConstraint = new NotSyntheticAccountConstraint();

            // act
            bool isNotSynthetic = notSythenticAccountConstraint.Verify(bankAccount);

            // assert
            Assert.IsTrue(isNotSynthetic);
        }

        [TestMethod]
        public void VerifySythenticAccount()
        {
            // arrange
            var bankAccount = new BankAccount { Synthetic = true };
            var notSythenticAccountConstraint = new NotSyntheticAccountConstraint();

            // act
            bool isNotSynthetic = notSythenticAccountConstraint.Verify(bankAccount);

            // assert
            Assert.IsFalse(isNotSynthetic);
        }
    }
}