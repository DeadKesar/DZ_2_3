using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.lsp
{
    internal class Case2
    {
        public abstract class Account // создаём абстрактный класс, в котором прописываем общие функции для обычного и замороженного аккаунтов
        {
            public string AccountNumber { get; set; }
            public abstract void Deposit(double amount);
            public abstract void Withdraw(double amount);
            public abstract string GetAccountInfo();
        }
        public class BankAccount : Account // наследование абстрактного класса 
        {
            public string AccountNumber { get; set; } = Guid.NewGuid().ToString();
            public double Balance { get; set; }

            public override void Deposit(double amount)
            {
                Balance += amount;
                Console.WriteLine("Deposited " + amount + " into account " + AccountNumber);
            }

            public override void Withdraw(double amount)
            {
                Balance -= amount;
                Console.WriteLine("Withdrew " + amount + " from account " + AccountNumber);
            }

            public void Transfer(BankAccount targetAccount, double amount)
            {
                Withdraw(amount);
                targetAccount.Deposit(amount);
                Console.WriteLine("Transferred " + amount + " from account " + AccountNumber + " to " + targetAccount.AccountNumber);
            }

            public override string GetAccountInfo()
            {
                return "Account: " + AccountNumber + " with balance: " + Balance;
            }

            public void UpdateAccountDetails()
            {
                Console.WriteLine("Updating account details for " + AccountNumber);
            }
        }

        public class FrozenAccount : Account // тоже наследование абстрактного класса
        {
            public string AccountNumber { get; set; } = Guid.NewGuid().ToString();
            public bool IsFrozen { get; set; } = true;

            public override void Withdraw(double amount)
            {
                Console.WriteLine($"Cannot withdraw from frozen account "  + AccountNumber);
            }

            public override void Deposit(double amount)
            {
                Console.WriteLine("Cannot deposit to a frozen account " + AccountNumber);
            }
            
            public override string GetAccountInfo()
            {
                return $"Frozen account: " + AccountNumber;
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

    }
}
