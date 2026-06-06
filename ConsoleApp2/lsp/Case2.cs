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
            public bool IsFrozen { get; set; } = false;

            public virtual void Deposit(double amount)
            {
                if (IsFrozen)
                {
                    throw new Exception("Account is frozen");
                }

                Balance += amount;
                Console.WriteLine($"Deposited {amount} into account {AccountNumber}");
            }

            public virtual void Withdraw(double amount)
            {
                if (IsFrozen)
                {
                    throw new Exception("Account is frozen");
                }

                Balance -= amount;
                Console.WriteLine($"Withdrew {amount} from account {AccountNumber}");
            }

            public virtual void Transfer(BankAccount targetAccount, double amount)
            {
                Withdraw(amount);
                targetAccount.Deposit(amount);
                Console.WriteLine($"Transferred {amount} from account {AccountNumber} to {targetAccount.AccountNumber}");
            }

            public virtual string GetAccountInfo()
            {
                return $"Account: {AccountNumber} with balance: {Balance}";
            }

            public void Freeze()
            {
                IsFrozen = true;
                Console.WriteLine($"Account {AccountNumber} is frozen");
            }

            public void Unfreeze()
            {
                IsFrozen = false;
                Console.WriteLine($"Account {AccountNumber} is now unfrozen");
            }
        }
    }
}
