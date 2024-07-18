namespace FinancialSystem
{
    public class Client
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public List<Account> Accounts { get; set; }

        public Client(string name, string password)
        {
            Name = name;
            Password = password;
            Accounts = new List<Account>();
        }

        public Client(string name, string password, List<Account> accounts)
        {
            Name = name;
            Password = password;
            Accounts = accounts ?? new List<Account>();
        }

        public Client()
        {
            Accounts = new List<Account>();
        }

        public bool VerifyPassword(string password)
        {
            return Password == password;
        }

        public void AddAccount(Account account)
        {
            Accounts.Add(account);
        }
    }
}
