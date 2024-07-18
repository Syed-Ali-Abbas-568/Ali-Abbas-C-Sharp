namespace FinancialSystem
{
    public class SavingsAccount : Account
    {
        private const double InterestRate = 0.05;

        public SavingsAccount() : base(0, AccountType.Savings)
        {
        }

        public override void ApplyInterestOrFees()
        {
            Balance += Balance * InterestRate;
        }

        public override void PrintBalance()
        {
            Console.Write($"Your SavingAccount balance is {Balance:C}\n");
        }
    }
}
