using System.Collections.Generic;
using Speedledger.AccountService.Models;

namespace Speedledger.AccountService.Mocks
{
    public class MockOnlySythenticBankAccountRepository : IBankAccountRepository
    {
        public IEnumerable<BankAccount> GetBankAccounts()
        {
            return new List<BankAccount>
            {
                new BankAccount { Id = 1, Number = "1357756", Name="Personal Account", CreditCard = false, Synthetic = true, Balance = 1202.14M  },
                new BankAccount { Id = 2, Number = "2446987", Name="Business Account", CreditCard = false, Synthetic = true, Balance = 34057.00M  },
                new BankAccount { Id = 3, Number = "9981644", Name="Credit card", CreditCard = true, Synthetic = true, Balance = -10057.00M  },
                new BankAccount { Id = 4, Number = "0", Name="Expense claims", CreditCard = false, Synthetic = true, Balance = 0M  },
            };
        }
    }
}