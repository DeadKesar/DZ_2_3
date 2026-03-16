namespace ConsoleApp2.lsp
{
    internal class Case2
    {
        public class BankAccount
        {
            public string AccountNumber { get; set; } = Guid.NewGuid().ToString();
            public double Balance { get; protected set; }

            public virtual void Deposit(double amount)
            {
                if (amount <= 0)
                    throw new ArgumentException("Amount must be positive");

                Balance += amount;
                Console.WriteLine($"Deposited {amount} into account {AccountNumber}");
            }

            public virtual void Withdraw(double amount)
            {
                if (amount <= 0)
                    throw new ArgumentException("Amount must be positive");

                if (Balance < amount)
                    throw new InvalidOperationException("Insufficient funds");

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

            public virtual void UpdateAccountDetails()
            {
                Console.WriteLine($"Updating account details for {AccountNumber}");
            }
        }

        public class FrozenAccount : BankAccount
        {
            public bool IsFrozen { get; private set; } = true;

            public override void Withdraw(double amount)
            {
                if (IsFrozen)
                    throw new InvalidOperationException("Account is frozen");

                base.Withdraw(amount);
            }

            public override void Deposit(double amount)
            {
                if (IsFrozen)
                    throw new InvalidOperationException("Account is frozen");

                base.Deposit(amount);
            }

            public void Freeze()
            {
                IsFrozen = true;
                Console.WriteLine($"Account {AccountNumber} is frozen");
            }

            public void Unfreeze()
            {
                IsFrozen = false;
                Console.WriteLine($"Account {AccountNumber} is unfrozen");
            }
        }
    }
}