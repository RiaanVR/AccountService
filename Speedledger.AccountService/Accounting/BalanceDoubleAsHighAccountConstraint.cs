using System.Collections.Generic;
using System.Linq;
using Speedledger.AccountService.Models;

namespace Speedledger.AccountService.Accounting
{
    /// <summary>
    /// Represents a constraint that default accounts should have a balance at least double as high as any other account.
    /// </summary>
    public class BalanceDoubleAsHighAccountConstraint : IDefaultAccountConstraint
    {
        private readonly IEnumerable<BankAccount> bankAccounts;

        public BalanceDoubleAsHighAccountConstraint(IEnumerable<BankAccount> bankAccounts)
        {
            this.bankAccounts = bankAccounts;
        }

        public bool Verify(BankAccount bankAccount)
        {
            var balanceMaximum = bankAccounts.Where(bankAcc => !bankAcc.Id.Equals(bankAccount.Id)).Max(bankAcc => bankAcc.Balance);

            return bankAccount.Balance > balanceMaximum * 2;
        }
    }
}