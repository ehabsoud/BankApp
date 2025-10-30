namespace HBBank.Interfaces;

/// <summary>
/// Represents a bank account.
/// Defines the basic properties and operations a bank account must support. 
/// </summary>
public interface IBankAccount
{
    // Gets the unique identifier of the account.
    Guid Id { get; }

    // Gets the name of the account.
    string Name { get; }


    // Gets the type of account (e.g., Savings, Deposit).
    AccountType AccountType { get; }

    // Gets the type of currency used by the account.
    string Currency { get; }


    // Gets the current balance of the account.
    decimal Balance { get; }

    // Gets the timestamp of the last update to the account.
    DateTime LastUpdated { get; }


    // The amount to withdraw.
    void Withdraw(decimal amount);


    // The amount to deposit. 
    void Deposit(decimal amount);
}