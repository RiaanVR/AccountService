using Microsoft.VisualStudio.TestTools.UnitTesting;
using Speedledger.AccountService.Models;

namespace Speedledger.AccountService.Accounting.Tests
{
    [TestClass()]
    public class PositiveAccountContstraintTests
    {
        [TestMethod]
        public void VerifyPositiveAccount()
        {
            // arrange
            var bankAccount = new BankAccount { Balance = 12300 };
            var positiveBalanceConstraint = new PositiveBalanceAccountContstraint();

            // act
            bool isPositive = positiveBalanceConstraint.Verify(bankAccount);

            // assert
            Assert.IsTrue(isPositive);
        }

        [TestMethod]
        public void VerifyNegativeAccount()
        {
            // arrange
            var bankAccount = new BankAccount { Balance = -1356.34M };
            var positiveBalanceConstraint = new PositiveBalanceAccountContstraint();

            // act
            bool isPositive = positiveBalanceConstraint.Verify(bankAccount);

            // assert
            Assert.IsFalse(isPositive);
        }
    }
}