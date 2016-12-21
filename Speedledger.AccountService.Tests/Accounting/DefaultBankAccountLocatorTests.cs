using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Speedledger.AccountService.Models;

namespace Speedledger.AccountService.Accounting.Tests
{
    [TestClass()]
    public class DefaultBankAccountLocatorTests
    {
        [TestMethod]
        public void ExpectNonSyntheticDefaultAccount()
        {
            // arrange
            var bankAccountRepository = new Mocks.MockRegularBankAccountRepository();
            var bankAccounts = bankAccountRepository.GetBankAccounts();
            var defaultAccountLocator = new DefaultBankAccountLocator(bankAccounts);
            var bankAccount = default(BankAccount);

            // act
            bankAccount = defaultAccountLocator.FindDefaultBankAccount();

            // assert
            Assert.IsFalse(bankAccount.Synthetic);
        }

        [TestMethod]
        public void ExpectDoublePositiveDefaultAccount()
        {
            // arrange
            var bankAccountRepository = new Mocks.MockRegularBankAccountRepository();
            var bankAccounts = bankAccountRepository.GetBankAccounts();
            var defaultAccountLocator = new DefaultBankAccountLocator(bankAccounts);
            var bankAccount = default(BankAccount);

            // act
            bankAccount = defaultAccountLocator.FindDefaultBankAccount();
            bool isDoubleHigher = bankAccounts.Where(bankAcc => !bankAcc.Id.Equals(bankAccount.Id)).All(bankAcc =>
              {
                  return (bankAcc.Balance * 2) < bankAccount.Balance;
              });

            // assert
            Assert.IsTrue(isDoubleHigher);
        }

        [TestMethod]
        public void ExpectNullAmongOnlySyntheticAccounts()
        {
            // arrange
            var bankAccountRepository = new Mocks.MockOnlySythenticBankAccountRepository();
            var bankAccounts = bankAccountRepository.GetBankAccounts();
            var defaultAccountLocator = new DefaultBankAccountLocator(bankAccounts);
            var bankAccount = default(BankAccount);

            // act
            bankAccount = defaultAccountLocator.FindDefaultBankAccount();

            // assert
            Assert.IsNull(bankAccount);
        }

        [TestMethod]
        public void ExpectNullAmongOnlyNegativeAccounts()
        {
            // arrange
            var bankAccountRepository = new Mocks.MockNegativeBankAccountRepository();
            var bankAccounts = bankAccountRepository.GetBankAccounts();
            var defaultAccountLocator = new DefaultBankAccountLocator(bankAccounts);
            var bankAccount = default(BankAccount);

            // act
            bankAccount = defaultAccountLocator.FindDefaultBankAccount();

            // assert
            Assert.IsNull(bankAccount);
        }

        [TestMethod]
        public void ExpectNullAmongNoHighBalanceAccounts()
        {
            // arrange
            var bankAccountRepository = new Mocks.MockNoHighBalanceBankAccountRepository();
            var bankAccounts = bankAccountRepository.GetBankAccounts();
            var defaultAccountLocator = new DefaultBankAccountLocator(bankAccounts);
            var bankAccount = default(BankAccount);

            // act
            bankAccount = defaultAccountLocator.FindDefaultBankAccount();

            // assert
            Assert.IsNull(bankAccount);
        }
    }
}