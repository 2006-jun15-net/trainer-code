using System;
using System.Collections.Generic;

namespace classes
{
    public class BankAccount
    {

        public string Number { get; }

        private string owner;

        public string Owner
        {
            get
            {
                return owner;
            }
            set
            {
                // inside a property setter, we have the keyword "value"
                if (string.IsNullOrWhiteSpace(value))
                {
                    // throw new ArgumentOutOfRangeException(nameof(value), "invalid name");
                    // throw new ArgumentNullException(nameof(value), "it's null");
                    throw new ArgumentException(message: "invalid name", paramName: nameof(value));
                }
                owner = value;
            }
        }

        public decimal Balance
        {
            get
            {
                Console.WriteLine("(inside the Balance getter running logic)");
                decimal balance = 0;
                foreach (var item in allTransactions)
                {
                    balance += item.Amount;
                }

                return balance;
            }
        }

        private static int accountNumberSeed = 1234567890;

        public BankAccount(string name, decimal initialBalance)
        {
            this.Number = accountNumberSeed.ToString();
            accountNumberSeed++;

            this.Owner = name;
            MakeDeposit(initialBalance, DateTime.Now, "Initial balance");
        }

        private List<Transaction> allTransactions = new List<Transaction>();

        public void MakeDeposit(decimal moneyAmount, DateTime date, string note)
        {
            if (moneyAmount <= 0)
            {
                Console.WriteLine(nameof(moneyAmount)); // prints "moneyAmount"
                Console.WriteLine("amount"); // prints "amount"
                Console.WriteLine(moneyAmount); // prints amount (e.g. 25.0)
                throw new ArgumentOutOfRangeException(nameof(moneyAmount), "Amount of deposit must be positive");
            }
            var deposit = new Transaction(moneyAmount, date, note);
            allTransactions.Add(deposit);
        }

        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
            }
            if (Balance - amount < 0)
            {
                throw new InvalidOperationException("Not sufficient funds for this withdrawal");
            }
            var withdrawal = new Transaction(-amount, date, note);
            allTransactions.Add(withdrawal);
        }

        public string GetAccountHistory()
        {
            var report = new System.Text.StringBuilder();

            decimal balance = 0;
            report.AppendLine("Date\t\tAmount\tBalance\tNote");
            foreach (var item in allTransactions)
            {
                balance += item.Amount;
                report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{balance}\t{item.Notes}");
            }

            return report.ToString();
        }
    }

    public class BankAccountJava
    {
        private string number;
        private string owner;

        public string GetNumber() {
            return number;
        }

        public string GetOwner() {
            return owner;
        }

        public void SetOwner(string owner) {
            this.owner = owner;
        }

        public decimal GetBalance() {
            decimal balance = 0;
            // foreach (var item in allTransactions)
            // {
            //     balance += item.Amount;
            // }

            return balance;
        }
    }
}
