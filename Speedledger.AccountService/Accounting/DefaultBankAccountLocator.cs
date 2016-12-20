using Speedledger.AccountService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Speedledger.AccountService.Accounting
{
    public class DefaultBankAccountLocator
    {
        private readonly IEnumerable<BankAccount> bankAccounts;

        public DefaultBankAccountLocator(IEnumerable<BankAccount> bankAccounts)
        {
            this.bankAccounts = bankAccounts;
        }

        public BankAccount FindDefaultBankAccount()
        {
            return bankAccounts.FirstOrDefault(bankAcc =>
            {
                return IsAccountBalanceDoubleAsHigh(bankAcc, bankAccounts) 
                && IsAccountNotSynthetic(bankAcc) 
                && IsAccountNotNegative(bankAcc);
            });
        }

        private static bool IsAccountBalanceDoubleAsHigh(BankAccount account, IEnumerable<BankAccount> bankAccounts)
        {
            var balanceMaximum = bankAccounts.Where(bankAcc => !bankAcc.Id.Equals(account.Id)).Max(bankAcc => bankAcc.Balance);

            return account.Balance > balanceMaximum * 2;
        }

        private static bool IsAccountNotSynthetic(BankAccount account)
        {
            return !account.Synthetic;
        }

        private static bool IsAccountNotNegative(BankAccount account)
        {
            return account.Balance > 0;
        }        
    }
}