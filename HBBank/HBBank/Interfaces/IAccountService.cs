using HBBank.Domain;

namespace HBBank.Interfaces;

/// <summary>
/// Provides methods for managing bank accounts and their transactions.
/// Defines the operations for creating accounts, retrieving accounts and transactions,
/// adding transactions, and saving account data. 
/// </summary>
public interface IAccountService
{
    // Creates a new bank account with the specified data.
    Task<IBankAccount> CreateAccount(string name, AccountType accountType, string currency, decimal initialBalance);

    // Retrieves all bank accounts.
    Task<List<IBankAccount>> GetAccounts();

    // Adds a transaction for a specified account.
    Task AddTransaction(Transaction transaction);

    // Retrieves all transactions for a specified account
    Task<List<Transaction>> GetTransactions(Guid accountId);

    // Saves all account data persistently. 
    Task SaveAccounts();
}