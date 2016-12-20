using Speedledger.AccountService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Speedledger.AccountService.Controllers
{
    public class BankAccountsController : ApiController
    {
        private IBankAccountRepository bankAccountRepository;

        public BankAccountsController() : this(new BankAccountRepository())
        { }

        public BankAccountsController(IBankAccountRepository bankAccountRepository)
        {
            this.bankAccountRepository = bankAccountRepository;
        }

        // GET: /bankaccounts
        [Route(template: "bankaccounts")]
        public IEnumerable<BankAccount> Get()
        {
            return bankAccountRepository.GetBankAccounts();
        }

        [Route(template: "bankaccounts/default")]
        public int? GetDefault()
        {
            var defaultBankAccountLocator = new Accounting.DefaultBankAccountLocator(bankAccountRepository.GetBankAccounts());

            return defaultBankAccountLocator.FindDefaultBankAccount()?.Id;
        }
    }
}
