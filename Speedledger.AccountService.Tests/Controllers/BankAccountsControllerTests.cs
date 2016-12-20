using Microsoft.VisualStudio.TestTools.UnitTesting;
using Speedledger.AccountService.Controllers;
using Speedledger.AccountService.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Speedledger.AccountService.Tests.Controllers
{
    [TestClass]
    public class BankAccountsControllerTests
    {
        [TestMethod]
        public void ExpectAllBankAccounts()
        {
            // arrange
            var controller = new BankAccountsController(new Mocks.MockRegularBankAccountRepository());
            var products = default(IEnumerable<BankAccount>);

            // act
            products = controller.Get();

            // assert
            Assert.AreEqual(4, products.Count());
        }

        [TestMethod]
        public void ExpectNoBankAccounts()
        {
            // arrange
            var controller = new BankAccountsController(new Mocks.MockNoBankAccountRepository());
            var products = default(IEnumerable<BankAccount>);

            // act
            products = controller.Get();

            // assert
            Assert.AreEqual(0, products.Count());
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void ExpectNullReference()
        {
            // arrange
            var controller = new BankAccountsController(null);

            // act
            controller.Get();

            // assert
            Assert.Fail();
        }

        [TestMethod]
        public void ExpectValidIdDefaultAccount()
        {
            // arrange 
            var bankAccountRepository = new Mocks.MockRegularBankAccountRepository();
            var bankAccountsController = new BankAccountsController(bankAccountRepository);
            var bankAccounts = bankAccountRepository.GetBankAccounts();
            var Id = default(int?);

            // act
            Id = bankAccountsController.GetDefault();

            // assert
            Assert.IsTrue(Id > 0);
        }

        [TestMethod]
        public void ExpectPositiveDefaultAccount()
        {
            // arrange 
            var bankAccountRepository = new Mocks.MockRegularBankAccountRepository();
            var bankAccountsController = new BankAccountsController(bankAccountRepository);
            var bankAccounts = bankAccountRepository.GetBankAccounts();
            var Id = default(int?);
            var bankAccount = default(BankAccount);

            // act
            Id = bankAccountsController.GetDefault();
            bankAccount = bankAccounts.FirstOrDefault(bankAcc => bankAcc.Id.Equals(Id));

            // assert
            Assert.IsTrue(bankAccount.Balance > 0);
        }

        [TestMethod]
        public void ExpectNonSyntheticDefaultAccount()
        {
            // arrange 
            var bankAccountRepository = new Mocks.MockRegularBankAccountRepository();
            var bankAccountsController = new BankAccountsController(bankAccountRepository);
            var bankAccounts = bankAccountRepository.GetBankAccounts();
            var Id = default(int?);
            var bankAccount = default(BankAccount);

            // act
            Id = bankAccountsController.GetDefault();
            bankAccount = bankAccounts.FirstOrDefault(bankAcc => bankAcc.Id.Equals(Id));

            // assert
            Assert.IsFalse(bankAccount.Synthetic);
        }

        [TestMethod]
        public void ExpectDoublePositiveDefaultAccount()
        {
            // arrange 
            var bankAccountRepository = new Mocks.MockRegularBankAccountRepository();
            var bankAccountsController = new BankAccountsController(bankAccountRepository);
            var bankAccounts = bankAccountRepository.GetBankAccounts();
            var Id = default(int?);
            var bankAccount = default(BankAccount);

            // act
            Id = bankAccountsController.GetDefault();
            bankAccount = bankAccounts.FirstOrDefault(bankAcc => bankAcc.Id.Equals(Id));
            bool isDoubleHigher = bankAccounts.Any(bankAcc =>
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
            var bankAccountsController = new BankAccountsController(bankAccountRepository);
            var Id = default(int?);

            // act
            Id = bankAccountsController.GetDefault();

            // assert
            Assert.IsNull(Id);
        }

        [TestMethod]
        public void ExpectNullAmongOnlyNegativeAccounts()
        {
            // arrange 
            var bankAccountRepository = new Mocks.MockNegativeBankAccountRepository();
            var bankAccountsController = new BankAccountsController(bankAccountRepository);
            var Id = default(int?);

            // act
            Id = bankAccountsController.GetDefault();

            // assert
            Assert.IsNull(Id);
        }

        [TestMethod]
        public void ExpectNullAmongNoHighBalanceAccounts()
        {
            // arrange 
            var bankAccountRepository = new Mocks.MockNegativeBankAccountRepository();
            var bankAccountsController = new BankAccountsController(bankAccountRepository);
            var Id = default(int?);

            // act
            Id = bankAccountsController.GetDefault();

            // assert
            Assert.IsNull(Id);
        }
    }
}
