using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Speedledger.AccountService.Models;

namespace Speedledger.AccountService.Controllers.Tests
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
    }
}