using System;

namespace ConsoleApp2.lsp
{
    internal class Case2
    {
        // бьазовый контракт
        public interface IAccount
        {
            string AccountNumber { get; }
            double Balance { get; }
            string GetAccountInfo();
            void UpdateAccountDetails();
        }

        // расширенный контракт
        public interface ITransactableAccount : IAccount
        {
            void Deposit(double amount);
            void Withdraw(double amount);
            void Transfer(ITransactableAccount target, double amount);
        }

        public class BankAccount : ITransactableAccount
        {
            public string AccountNumber { get; set; } = Guid.NewGuid().ToString();
            public double Balance { get; set; }

            public void Deposit(double amount)
            {
                Balance += amount;
                Console.WriteLine("Deposited " + amount + " into account " + AccountNumber);
            }

            public void Withdraw(double amount)
            {
                Balance -= amount;
                Console.WriteLine("Withdrew " + amount + " from account " + AccountNumber);
            }

            public void Transfer(ITransactableAccount target, double amount)
            {
                Withdraw(amount);
                target.Deposit(amount);
                Console.WriteLine("Transferred " + amount + " from " + AccountNumber + " to " + target.AccountNumber);
            }

            public string GetAccountInfo()
            {
                return "Account: " + AccountNumber + " with balance: " + Balance;
            }

            public void UpdateAccountDetails()
            {
                Console.WriteLine("Updating account details for " + AccountNumber);
            }
        }

        public class FrozenAccount : IAccount
        {
            public string AccountNumber { get; set; } = Guid.NewGuid().ToString();
            public double Balance { get; set; }
            public bool IsFrozen { get; private set; } = true;

            public string GetAccountInfo()
            {
                return "Frozen account: " + AccountNumber + " with balance: " + Balance;
            }

            public void UpdateAccountDetails()
            {
                Console.WriteLine("Updating account details for " + AccountNumber);
            }

            public void Unfreeze()
            {
                IsFrozen = false;
                Console.WriteLine("Account " + AccountNumber + " is now unfrozen");
            }

            public void Freeze()
            {
                IsFrozen = true;
                Console.WriteLine("Account " + AccountNumber + " is frozen again");
            }
        }

        class Program
        {
            static void Main()
            {
                BankAccount account = new BankAccount();
                account.Deposit(1000);
                account.Withdraw(200);
                Console.WriteLine(account.GetAccountInfo());

                FrozenAccount frozen = new FrozenAccount { Balance = 500 };
                Console.WriteLine(frozen.GetAccountInfo());
                frozen.Unfreeze();
            }
        }
    }
}
