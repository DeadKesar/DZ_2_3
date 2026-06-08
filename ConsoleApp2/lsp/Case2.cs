using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.lsp
{
    internal class Case2
    {


        public class BankAccount
        {
            public string AccountNumber { get; set; } = Guid.NewGuid().ToString();
            public double Balance { get; set; }

            public virtual void Deposit(double amount)
            {
                Balance += amount;
                Console.WriteLine("Deposited " + amount + " into account " + AccountNumber);
            }

            public virtual void Withdraw(double amount)
            {
                Balance -= amount;
                Console.WriteLine("Withdrew " + amount + " from account " + AccountNumber);
            }

            public virtual void Transfer(BankAccount targetAccount, double amount)
            {
                Withdraw(amount);
                targetAccount.Deposit(amount);
                Console.WriteLine("Transferred " + amount + " from account " + AccountNumber + " to " + targetAccount.AccountNumber);
            }

            public virtual string GetAccountInfo()
            {
                return "Account: " + AccountNumber + " with balance: " + Balance;
            }

            public virtual void UpdateAccountDetails()
            {
                Console.WriteLine("Updating account details for " + AccountNumber);
            }
        }
        public class FrozenAccount : BankAccount
        {
            public bool IsFrozen { get; set; } = true;

            public override void Withdraw(double amount)
            { }

            public override void Deposit(double amount)
            {
                Console.WriteLine("Cannot deposit to a frozen account " + AccountNumber);
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




    // Нарушение принципа LSP было в том, что класс FrozenAccount наследовался от BankAccount, но отключал или ломал его базовые методы (Withdraw и Deposit). 
    // Наследник нарушал поведение родительского класса: мы ожидаем, что с любого BankAccount можно снять деньги, но с замороженного этого сделать нельзя (он молча игнорировал вызов).
    // надо выделить операции снятия и пополнения в интерфейсы IDepositable и IWithdrawable. 
    // Обычный рабочий счет ActiveBankAccount реализует эти интерфейсы, а FrozenAccount — нет. Теперь их нельзя перепутать в коде.
    class Case2better
    {
        // Базовый класс для любого счета (хранит только баланс и общую информацию)
        public class BaseAccount
        {
            public string AccountNumber { get; set; } = Guid.NewGuid().ToString();
            public double Balance { get; protected set; }

            public virtual string GetAccountInfo()
            {
                return "Account: " + AccountNumber + " with balance: " + Balance;
            }
        }

        // Интерфейс для счетов, которые можно пополнять
        public interface IDepositable
        {
            void Deposit(double amount);
        }

        // Интерфейс для счетов, с которых можно снимать деньги
        public interface IWithdrawable
        {
            void Withdraw(double amount);
        }

        // Рабочий банковский счет, поддерживающий все стандартные операции
        public class ActiveBankAccount : BaseAccount, IDepositable, IWithdrawable
        {
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

            // Переводить деньги теперь можно только между теми счетами, которые поддерживают эти операции
            public void Transfer(IWithdrawable source, IDepositable target, double amount)
            {
                source.Withdraw(amount);
                target.Deposit(amount);
                Console.WriteLine("Transferred " + amount + " from source to target.");
            }
        }



        // Замороженный счет теперь просто не реализует интерфейсы пополнения и снятия
        public class FrozenAccount : BaseAccount
        {
            public bool IsFrozen { get; set; } = true;

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
