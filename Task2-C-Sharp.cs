﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace FinancialSystem
{
    public enum AccountType
    {
        Savings,
        Checking,
        Investment
    }

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

    public class FinancialSystem
    {
        private List<Client> _clients;

        public FinancialSystem()
        {
            _clients = new List<Client>();
        }

        public void SignUp()
        {
            Console.Clear();
            Console.WriteLine("Enter your details:");

            string name = InputField("UserName: ");
            string password = InputField("Password: ");

            var client = new Client(name, password);
            _clients.Add(client);

            Console.WriteLine("SignUp successful!");
        }

        public void Login()
        {
            Console.Clear();
            Console.WriteLine("Enter your login details:");

            string name = InputField("UserName: ");
            string password = InputField("Password: ");

            var client = _clients.Find(c => c.Name == name);
            if (client != null && client.VerifyPassword(password))
            {
                Console.WriteLine("Login successful!");
                ClientMenu(client);
            }
            else
            {
                Console.WriteLine("Invalid credentials.");
            }
        }

        public void Start()
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("WELCOME CUSTOMER TO ARBI BANKING");
                Console.WriteLine("1. Login (existing user)");
                Console.WriteLine("2. Sign Up (new customer)");
                Console.WriteLine("3. Exit");
                Console.Write("CHOICE: ");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Login();
                            break;
                        case 2:
                            SignUp();
                            break;
                        case 3:
                            Console.WriteLine("Thank you for using my program.");
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("INVALID INPUT");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("INVALID INPUT");
                }
            }
        }

        private string InputField(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

        private void ClientMenu(Client client)
        {
            Console.Clear();
            Console.WriteLine($"Welcome {client.Name}!");
            Console.WriteLine("1. View Accounts");
            Console.WriteLine("2. Add Account");
            Console.WriteLine("3. Add or Remove Balance from any account");
            Console.WriteLine("4. Apply Interest/Fees");
            Console.WriteLine("5. Log Out");

            Console.Write("CHOICE: ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        ViewAccounts(client);
                        break;
                    case 2:
                        AddAccount(client);
                        break;
                    case 3:
                        SetBalance(client);
                        break;
                    case 4:
                        ApplyInterestOrFees(client);
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("INVALID INPUT");
                        break;
                }
                ClientMenu(client);
            }
            else
            {
                Console.WriteLine("INVALID INPUT");
            }
        }

        private void ViewAccounts(Client client)
        {
            Console.Clear();
            Console.WriteLine("Your Accounts:");
            foreach (var account in client.Accounts)
            {
                account.PrintBalance();
            }
            Console.WriteLine("Press any key to return to menu...");
            Console.ReadKey();
        }

        private void SetBalance(Client client)
        {
            Console.Clear();
            Console.WriteLine("Your Accounts:");
            for (int i = 0; i < client.Accounts.Count; i++)
            {
                Console.Write($"{i}. ");
                client.Accounts[i].PrintBalance();
            }
            Console.WriteLine("Choose Account to Update:");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Amount to be added (to remove simply write negative value)");
                if (int.TryParse(Console.ReadLine(), out int amount))
                {
                    if ((client.Accounts[choice].Balance + amount) >= 0)
                    {
                        client.Accounts[choice].Balance += amount;
                        Console.WriteLine("Balance Updated Successfully");
                    }
                    else
                    {
                        Console.WriteLine("Invalid Amount Entered. Aborted Transaction");
                    }
                }

                Console.WriteLine("Press any key to return to menu...");
                Console.ReadKey();
            }
        }

        private void AddAccount(Client client)
        {
            Console.Clear();
            Console.WriteLine("Select Account Type:");
            Console.WriteLine("1. Savings");
            Console.WriteLine("2. Checking");
            Console.WriteLine("3. Investment");
            Console.Write("CHOICE: ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                Account newAccount;
                switch (choice)
                {
                    case 1:
                        newAccount = new SavingsAccount();
                        break;
                    case 2:
                        newAccount = new CheckingAccount();
                        break;
                    case 3:
                        newAccount = new InvestmentAccount();
                        break;
                    default:
                        newAccount = null;
                        break;
                }

                if (newAccount != null)
                {
                    client.AddAccount(newAccount);
                    Console.WriteLine("Account added successfully!");
                }
                else
                {
                    Console.WriteLine("Invalid account type.");
                }
            }
            else
            {
                Console.WriteLine("INVALID INPUT");
            }

            Console.WriteLine("Press any key to return to menu...");
            Console.ReadKey();
        }

        private void ApplyInterestOrFees(Client client)
        {
            Console.Clear();
            foreach (var account in client.Accounts)
            {
                account.ApplyInterestOrFees();
            }
            Console.WriteLine("Interest/Fees applied to all accounts.");
            Console.WriteLine("Press any key to return to menu...");
            Console.ReadKey();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var app = new FinancialSystem();
            app.Start();
        }
    }
}
