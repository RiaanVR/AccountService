using Speedledger.AccountService.Models;

namespace Speedledger.AccountService.Accounting
{
    /// <summary>
    /// Represents a contstraint that default accounts can not have a negative balance
    /// </summary>
    public class PositiveBalanceAccountContstraint : IDefaultAccountConstraint
    {
        public bool Verify(BankAccount bankAccount)
        {
            return bankAccount.Balance > 0;
        }
    }
}