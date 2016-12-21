using System.Collections.Generic;

namespace Speedledger.AccountService.Models
{
    /// <summary>
    ///  Represents a common interface for retrieval of Bank Accounts.
    /// </summary>
    public interface IBankAccountRepository
    {
        IEnumerable<BankAccount> GetBankAccounts();
    }
}