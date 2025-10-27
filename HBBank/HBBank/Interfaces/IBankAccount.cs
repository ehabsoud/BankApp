namespace HBBank.Interfaces;

/// <summary>
/// Represents a bank account.
/// Defines the basic properties and operations a bank account must support. 
/// </summary>
public interface IBankAccount
{
    /// <summary>
    /// Gets the unique identifier of the account.
    /// </summary>
    Guid Id { get; }

    /// <summary>
    /// Gets the name of the account.
    /// </summary>
    string Name { get; }

    /// <summary>
    /// Gets the type of account (e.g., Savings, Deposit).
    /// </summary>
    AccountType AccountType { get; }

    /// <summary>
    /// Gets the type of currency used by the account.
    /// </summary>
    string Currency { get; }

    /// <summary>
    /// Gets the current balance of the account.
    /// </summary>
    decimal Balance { get; }

    /// <summary>
    /// Gets the timestamp of the last update to the account.
    /// </summary>
    DateTime LastUpdated { get; }

    /// <summary>
    /// The amount to withdraw.
    /// </summary>
    /// <param name="amount">The amount to withdraw.</param>
    void Withdraw(decimal amount);

    /// <summary>
    /// The amount to deposit. 
    /// </summary>
    /// <param name="amount"></param>
    void Deposit(decimal amount);
}