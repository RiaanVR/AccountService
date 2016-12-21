using System.Collections.Generic;
using System.Linq;
using Speedledger.AccountService.Models;

namespace Speedledger.AccountService.Mocks
{
    internal class MockNoBankAccountRepository : IBankAccountRepository
    {
        public IEnumerable<BankAccount> GetBankAccounts()
        {
            return Enumerable.Empty<BankAccount>();
        }
    }
}