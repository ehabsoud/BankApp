namespace HBBank.Interfaces;

/// <summary>
/// Interface containing the BankAccount methods
/// </summary>
public interface IBankAccount
{
    Guid Id { get; }
    string Name { get; }
    AccountType AccountType { get; }
    string Currency { get; }
    decimal Balance { get; }
    DateTime LastUpdated { get; }
    
    void Withdraw(decimal amount);
    void Deposit(decimal amount);
}