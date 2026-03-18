namespace ConsoleApp2.lsp
{
    internal class Case2
    {
        public class BankAccount
        {
            public string AccountNumber { get; set; } = Guid.NewGuid().ToString();
            public double Balance { get; protected set; }

            public bool IsFrozen { get; protected set; }

            protected void EnsureNotFrozen()
            {
                if (IsFrozen)
                    throw new InvalidOperationException("Account is frozen");
            }

            public virtual void Deposit(double amount)
            {
                EnsureNotFrozen();
                Balance += amount;
                Console.WriteLine("Deposited " + amount + " into account " + AccountNumber);
            }

            public virtual void Withdraw(double amount)
            {
                EnsureNotFrozen();
                Balance -= amount;
                Console.WriteLine("Withdrew " + amount + " from account " + AccountNumber);
            }

            public virtual void Transfer(BankAccount targetAccount, double amount)
            {
                if (targetAccount == null)
                    throw new ArgumentNullException(nameof(targetAccount));

                EnsureNotFrozen();
                targetAccount.EnsureNotFrozen();

                Withdraw(amount);
                targetAccount.Deposit(amount);

                Console.WriteLine("Transferred " + amount + " from account " + AccountNumber + " to " + targetAccount.AccountNumber);
            }

            public virtual string GetAccountInfo()
            {
                return "Account: " + AccountNumber + " with balance: " + Balance +
                       (IsFrozen ? " (Frozen)" : " (Active)");
            }

            public virtual void UpdateAccountDetails()
            {
                Console.WriteLine("Updating account details for " + AccountNumber);
            }

            public void Freeze()
            {
                IsFrozen = true;
                Console.WriteLine("Account " + AccountNumber + " is frozen");
            }

            public void Unfreeze()
            {
                IsFrozen = false;
                Console.WriteLine("Account " + AccountNumber + " is unfrozen");
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