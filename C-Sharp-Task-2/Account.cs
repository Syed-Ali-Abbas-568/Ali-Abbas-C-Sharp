namespace FinancialSystem
{
    public abstract class Account
    {
        public double Balance { get; set; }
        public AccountType AccountType { get; set; }

        protected Account(double balance, AccountType accountType)
        {
            Balance = balance;
            AccountType = accountType;
        }

        protected Account()
        {
        }

        public abstract void ApplyInterestOrFees();
        public abstract void PrintBalance();
    }
}
