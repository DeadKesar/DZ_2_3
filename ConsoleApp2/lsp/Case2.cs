using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.lsp
{
    internal class Case2
    {
        // Базовый интерфейс-основа
        public interface IAccount
        {
            string AccountNumber { get; }
            double Balance { get; }
            string GetAccountInfo(); 
            void UpdateAccountDetails();
        }

        // Интерфейс для аккаунтов способных к транзакциям
        public interface ITransactableAccount : IAccount
        {
            void Deposit(double amount);
            void Withdraw(double amount);
            void Transfer(ITransactableAccount target, double amount);
        }

        // Некий активный счёт, на данном уровне не важно - какой он, юридический или физический
        public class BankAccount : ITransactableAccount
        {
            public string AccountNumber { get; private set; } = Guid.NewGuid().ToString();
            public double Balance { get; private set; } // Публичный сет это нарушение инкапсуляции

            // Конструктор вместо публичного сета
            public BankAccount(double initialBalance = 0)
            {
                if (initialBalance < 0)
                    throw new ArgumentException("Initial balance cannot be negative.");
                Balance = initialBalance;
            }

            public void Deposit(double amount)
            {
                // Добавил проверку на необходимую положительность
                if (amount <= 0)
                    throw new ArgumentException("Deposit amount must be positive.");

                Balance += amount;
                Console.WriteLine("Deposited " + amount + " into account " + AccountNumber);
            }

            public void Withdraw(double amount)
            {
                // Добавил проверки на границы 
                if (amount <= 0)
                    throw new ArgumentException("Withdrawal amount must be positive.");

                if (amount > Balance)
                    throw new InvalidOperationException("Insufficient funds.");

                Balance -= amount;
                Console.WriteLine("Withdrew " + amount + " from account " + AccountNumber);
            }

            public void Transfer(ITransactableAccount target, double amount)
            {
                // Добавил проверку на предотвращение оффшоров
                if (target == null)
                    throw new ArgumentNullException(nameof(target));

                Withdraw(amount);
                target.Deposit(amount);
                Console.WriteLine("Transferred " + amount + " from " + AccountNumber + " to " + target.AccountNumber);
            }

            public string GetAccountInfo() =>
                "Account: " + AccountNumber + " with balance: " + Balance;

            public void UpdateAccountDetails() =>
                Console.WriteLine("Updating account details for " + AccountNumber);
        }

        // Счёт под санкциями
        public class FrozenAccount : IAccount
        {
            public string AccountNumber { get; private set; } = Guid.NewGuid().ToString();
            public double Balance { get; private set; } // Публичный сет это нарушение инкапсуляции 
            public bool IsFrozen { get; private set; } = true; // Не понимаю смысл флага, удалил бы

            // Конструктор вместо публичного сета
            public FrozenAccount(double initialBalance = 0)
            {
                Balance = initialBalance;
            }

            public string GetAccountInfo() =>
                "Frozen account: " + AccountNumber + " with balance: " + Balance;

            public void UpdateAccountDetails() =>
                Console.WriteLine("Updating account details for "+ AccountNumber);

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
