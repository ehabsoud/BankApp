using System.Text.Json.Serialization;

namespace HBBank.Domain;

/// <summary>
/// Represents a bank account in the system.
/// Contains information about the account's ID, name, type, currency, balance, and last update time.
/// </summary>
public class BankAccount : IBankAccount
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Name { get; private set; }
    public AccountType AccountType { get; private set; }
    public string Currency { get; private set; }
    public decimal Balance { get; private set; }
    public DateTime LastUpdated { get; private set; }

    /// <summary>
    /// Creates a new bank account with the specified name, type, currency and initial balance.
    /// </summary>
    /// <param name="name">The name of the account.</param>
    /// <param name="accountType">The type of account.</param>
    /// <param name="currency">The type of currency used by the account.</param>
    /// <param name="balance">The initial balance of the account.</param>
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

    /// <summary>
    /// Withdraws a specified amount from the account.
    /// </summary>
    /// <param name="amount">The amount to withdraw, must not be negative, and must not exceed current balance.</param>
    /// <exception cref="ArgumentException">Thrown when the amount is negative or zero.</exception>
    /// <exception cref="Exception">Thrown when the amount exceeds the current balance.</exception>
    public void Withdraw(decimal amount)
    {
        if (amount < 0)
            throw new ArgumentException("Amount cannot be negative");

        if (amount > Balance)
            throw new Exception("Amount cannot be greater than balance");

        Balance -= amount;
        LastUpdated = DateTime.Now;
    }

    /// <summary>
    /// Deposits a specified amount into the account.
    /// </summary>
    /// <param name="amount">The amount to deposit, must be greater than zero.</param>
    /// <exception cref="ArgumentException">Thrown when the amount is negative or zero.</exception>
    public void Deposit(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Amount must be greater than zero");

        Balance += amount;
        LastUpdated = DateTime.Now;
    }
}