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
            public double Balance { get; private set; }
            public bool IsFrozen { get; private set; }

            public virtual void Deposit(double amount)
            {
                if (IsFrozen)
                    throw new InvalidOperationException($"Account {AccountNumber} is frozen. Deposit is not allowed.");

                if (amount <= 0)
                    throw new ArgumentException("Deposit amount must be greater than zero.");

                Balance += amount;
                Console.WriteLine($"Deposited {amount} into account {AccountNumber}");
            }

            public virtual void Withdraw(double amount)
            {
                if (IsFrozen)
                    throw new InvalidOperationException($"Account {AccountNumber} is frozen. Withdrawal is not allowed.");

                if (amount <= 0)
                    throw new ArgumentException("Withdrawal amount must be greater than zero.");

                if (amount > Balance)
                    throw new InvalidOperationException("Insufficient funds.");

                Balance -= amount;
                Console.WriteLine($"Withdrew {amount} from account {AccountNumber}");
            }

            public virtual void Transfer(BankAccount targetAccount, double amount)
            {
                if (targetAccount == null)
                    throw new ArgumentNullException(nameof(targetAccount));

                Withdraw(amount);
                targetAccount.Deposit(amount);

                Console.WriteLine($"Transferred {amount} from account {AccountNumber} to {targetAccount.AccountNumber}");
            }

            public virtual string GetAccountInfo()
            {
                string status = IsFrozen ? "Frozen" : "Active";
                return $"Account: {AccountNumber}, balance: {Balance}, status: {status}";
            }

            public virtual void UpdateAccountDetails()
            {
                Console.WriteLine($"Updating account details for {AccountNumber}");
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
