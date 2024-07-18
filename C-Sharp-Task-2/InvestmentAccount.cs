namespace FinancialSystem
{
    public class InvestmentAccount : Account
    {
        private const double InvestmentRate = 0.1;

        public InvestmentAccount() : base(0, AccountType.Investment)
        {
        }

        public override void ApplyInterestOrFees()
        {
            Balance += Balance * InvestmentRate;
        }

        public override void PrintBalance()
        {
            Console.WriteLine($"Your InvestmentAccount balance is {Balance:C}\n");
        }
    }
}
