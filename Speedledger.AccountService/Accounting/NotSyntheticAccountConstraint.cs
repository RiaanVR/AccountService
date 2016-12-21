using Speedledger.AccountService.Models;

namespace Speedledger.AccountService.Accounting
{
    /// <summary>
    /// Represents a constraint that default accounts can not be synthetic accounts.
    /// </summary>
    public class NotSyntheticAccountConstraint : IDefaultAccountConstraint
    {
        public bool Verify(BankAccount bankAccount)
        {
            return !bankAccount.Synthetic;
        }
    }
}