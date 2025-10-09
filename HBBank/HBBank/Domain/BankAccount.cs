namespace HB_Bank.Domain;

public class BankAccount : IBankAccount
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Name { get; private set; }
    public string Currency { get; private set; }
    public decimal Balance { get; private set; }
    public DateTime LastUpdated { get; private set; }
    
   
    public void Withdraw(decimal amount)
    {
        if (amount < 0)
            throw new ArgumentException("Amount cannot be negative");
        
        if (amount > Balance)
            throw new Exception("Amount cannot be greater than balance");
        
        Balance -= amount;
        LastUpdated = DateTime.Now;
    }

    public void Deposit(decimal amount)
    {
        if  (amount <= 0)
            throw new ArgumentException("Amount must be greater than zero");

        Balance += amount;
        LastUpdated = DateTime.Now;
    }
}