using System.Collections.Generic;
using System.Linq;
using Speedledger.AccountService.Models;

namespace Speedledger.AccountService.Accounting
{
    /// <summary>
    /// Represents the locator service that will find the default bank account among the account specified.
    /// </summary>
    public class DefaultBankAccountLocator
    {
        private readonly IEnumerable<BankAccount> bankAccounts;
        private readonly IEnumerable<IDefaultAccountConstraint> constraints;

        public DefaultBankAccountLocator(IEnumerable<BankAccount> bankAccounts) : this(bankAccounts, GetDefaultAccountConstraints(bankAccounts))
        {
        }

        public DefaultBankAccountLocator(IEnumerable<BankAccount> bankAccounts, IEnumerable<IDefaultAccountConstraint> constraints)
        {
            this.bankAccounts = bankAccounts;
            this.constraints = constraints;
        }

        /// <summary>
        /// Locate the default account
        /// </summary>
        /// <returns>Default Bank Account</returns>
        public BankAccount FindDefaultBankAccount()
        {
            return bankAccounts.FirstOrDefault(bankAcc =>
            {
                return constraints.All(constraint => constraint.Verify(bankAcc));
            });
        }

        /// <summary>
        /// Helper function to initialise the locator given no constraints were passed
        /// </summary>
        /// <param name="bankAccounts">IEnumerable of BankAccount</param>
        /// <returns>Default list of constraints</returns>
        private static IEnumerable<IDefaultAccountConstraint> GetDefaultAccountConstraints(IEnumerable<BankAccount> bankAccounts)
        {
            return new List<IDefaultAccountConstraint>()
            {
                new BalanceDoubleAsHighAccountConstraint(bankAccounts),
                new NotSyntheticAccountConstraint(),
                new PositiveBalanceAccountContstraint()
            };
        }
    }
}