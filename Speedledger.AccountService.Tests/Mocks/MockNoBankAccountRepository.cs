using System;
using System.Collections.Generic;
using Speedledger.AccountService.Models;
using System.Linq;

namespace Speedledger.AccountService.Tests.Mocks
{
    internal class MockNoBankAccountRepository : IBankAccountRepository
    {
        public IEnumerable<BankAccount> GetBankAccounts()
        {
            return Enumerable.Empty<BankAccount>();
        }
    }
}