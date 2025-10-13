using System.Text.Json.Serialization;

namespace HBBank.Domain;

public class BankAccount : IBankAccount
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Name { get; private set; }
    public AccountType AccountType { get; private set; }
    public string Currency { get; private set; }
    public decimal Balance { get; private set; }
    public DateTime LastUpdated { get; private set; }

    public BankAccount(string name, AccountType accountType, string currency, decimal balance)
    {
        Name = name;
        AccountType = accountType;
        Currency = currency;
        Balance = balance;
        LastUpdated = DateTime.Now;
    }

    [JsonConstructor]
    public BankAccount(Guid id, string name, AccountType accountType, string currency,
        decimal balance, DateTime lastUpdated)
    {
        Id = id;
        Name = name;
        AccountType = accountType;
        Currency = currency;
        Balance = balance;
        LastUpdated = lastUpdated;
    }
    
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

