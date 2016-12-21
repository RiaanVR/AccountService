using Microsoft.VisualStudio.TestTools.UnitTesting;
using Speedledger.AccountService.Models;

namespace Speedledger.AccountService.Accounting.Tests
{
    [TestClass()]
    public class BalanceDoubleAsHighAccountConstraintTests
    {
        [TestMethod]
        public void VerifyDoubleAsHighAsAnyOtherAccount()
        {
            // arrange
            var bankAccount = new BankAccount { Balance = 74500.23M };
            var bankAccounts = new Mocks.MockRegularBankAccountRepository().GetBankAccounts();
            var doubleAsHighAccountConstraint = new BalanceDoubleAsHighAccountConstraint(bankAccounts);

            // act
            bool isDoubleAsHigh = doubleAsHighAccountConstraint.Verify(bankAccount);

            // assert
            Assert.IsTrue(isDoubleAsHigh);
        }

        [TestMethod]
        public void VerifyNotDoubleAsHighAsAnyOtherAccount()
        {
            var bankAccount = new BankAccount { Balance = 23000.34M };
            var bankAccounts = new Mocks.MockRegularBankAccountRepository().GetBankAccounts();
            var doubleAsHighAccountConstraint = new BalanceDoubleAsHighAccountConstraint(bankAccounts);

            // act
            bool isDoubleAsHigh = doubleAsHighAccountConstraint.Verify(bankAccount);

            // assert
            Assert.IsFalse(isDoubleAsHigh);
        }
    }
}