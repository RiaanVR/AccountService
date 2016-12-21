namespace Speedledger.AccountService.Models
{
    /// <summary>
    /// Represents a singular instance of a bank account.
    /// </summary>
    public class BankAccount
    {
        /// <summary>
        /// Unique identifier for this account.
        /// </summary>
        public int Id
        {
            get; set;
        }

        /// <summary>
        /// The number used by the bank to identify this account
        /// </summary>
        public string Number
        {
            get; set;
        }

        /// <summary>
        /// Human-readable name of the bank account
        /// </summary>
        public string Name
        {
            get; set;
        }

        /// <summary>
        /// The amount of money (positive or negative) on the bank account
        /// </summary>
        public decimal Balance
        {
            get; set;
        }

        /// <summary>
        /// Whether this bank account represents a credit card
        /// </summary>
        public bool CreditCard
        {
            get; set;
        }

        /// <summary>
        /// True if a bank account is "synthetic", i.e representing some "bank account like" thing, but
        /// not an actual bank account
        /// </summary>
        public bool Synthetic
        {
            get; set;
        }
    }
}