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
        public abstract class BankAccount
        {
            public string AccountNumber { get; set; } = Guid.NewGuid().ToString();
            public double Balance { get; protected set; }
            public bool IsFrozen { get; protected set; }

            public virtual void Deposit(double amount)
            {
                if (IsFrozen)
                {
                    Console.WriteLine("Cannot deposit to frozen account " + AccountNumber);
                    return;
                }
                Balance += amount;
                Console.WriteLine("Deposited " + amount + " into account " + AccountNumber);
            }

            public virtual void Withdraw(double amount)
            {
                if (IsFrozen)
                {
                    Console.WriteLine("Cannot withdraw from frozen account " + AccountNumber);
                    return;
                }
                if (amount > Balance)
                {
                    Console.WriteLine("Insufficient funds");
                    return;
                }
                Balance -= amount;
                Console.WriteLine("Withdrew " + amount + " from account " + AccountNumber);
            }

            public virtual void Transfer(BankAccount targetAccount, double amount)
            {
                if (IsFrozen || targetAccount.IsFrozen)
                {
                    Console.WriteLine("Cannot transfer - one of accounts is frozen");
                    return;
                }
                Withdraw(amount);
                targetAccount.Deposit(amount);
                Console.WriteLine("Transferred " + amount + " from account " + AccountNumber + " to " + targetAccount.AccountNumber);
            }

            public virtual string GetAccountInfo()
            {
                string status = IsFrozen ? " (FROZEN)" : "";
                return "Account: " + AccountNumber + " with balance: " + Balance + status;
            }

            public virtual void UpdateAccountDetails()
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
                Console.WriteLine("Account " + AccountNumber + " is frozen");
            }
        }

        public class NormalAccount : BankAccount
        {
            public NormalAccount()
            {
                IsFrozen = false;
            }
        }

        public class FrozenAccount : BankAccount
        {
            public FrozenAccount()
            {
                IsFrozen = true;
            }
        }
    }
}
