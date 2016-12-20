using Speedledger.AccountService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Speedledger.AccountService.Tests.Mocks
{
    public class MockDefaultBankAccountRepository : IBankAccountRepository
    {
        public IEnumerable<BankAccount> GetBankAccounts()
        {
            throw new NotImplementedException();
        }
    }
}
