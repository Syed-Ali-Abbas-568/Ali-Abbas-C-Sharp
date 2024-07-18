namespace FinancialSystem
{
    public class CheckingAccount : Account
    {
        private const double MonthlyFee = 10.0;

        public CheckingAccount() : base(0, AccountType.Checking)
        {
        }

        public override void ApplyInterestOrFees()
        {
            Balance -= MonthlyFee;
        }

        public override void PrintBalance()
        {
            Console.WriteLine($"Your CheckingAccount balance is {Balance:C}\n");
        }
    }
}
