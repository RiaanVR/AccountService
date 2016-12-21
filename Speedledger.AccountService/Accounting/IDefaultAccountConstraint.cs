using Speedledger.AccountService.Models;

namespace Speedledger.AccountService.Accounting
{
    /// <summary>
    /// Represents a contraint that can be applied to verify whether the account matches or not
    /// </summary>
    public interface IDefaultAccountConstraint
    {
        bool Verify(BankAccount bankAccount);
    }
}