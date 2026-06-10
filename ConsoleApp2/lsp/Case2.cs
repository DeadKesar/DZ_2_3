using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.lsp
{
    // выполнить в папке LSP номер 3, а их там 0,1,2 так что я решил просто сделать 3 по счету

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
}
