using HBBank.Domain;

namespace HBBank.Interfaces;

/// <summary>
/// Provides methods for managing bank accounts and their transactions.
/// Defines the operations for creating accounts, retrieving accounts and transactions,
/// adding transactions, and saving account data. 
/// </summary>
public interface IAccountService
{
    /// <summary>
    /// Creates a new bank account with the specified details.
    /// </summary>
    /// <param name="name">The name of the account.</param>
    /// <param name="accountType">The type of account (e.g., Savings, Deposit).</param>
    /// <param name="currency">The currency used by the account.</param>
    /// <param name="initialBalance">The initial balance for the account.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the created <see cref="IBankAccount"/>.</returns>
    Task<IBankAccount> CreateAccount(string name, AccountType accountType, string currency, decimal initialBalance);

    /// <summary>
    /// Retrieve all bank accounts.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation. The task result contains a list of <see cref="IBankAccount"/>.</returns>
    Task<List<IBankAccount>> GetAccounts();

    /// <summary>
    /// Adds a transaction for a specified account. 
    /// </summary>
    /// <param name="transaction">The <see cref="Transaction"/> to add.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task AddTransaction(Transaction transaction);

    /// <summary>
    /// Retrieves all transactions for a specified account.
    /// </summary>
    /// <param name="accountId">The unique identifier of the account.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a list of <see cref="Transaction"/>.</returns>
    Task<List<Transaction>> GetTransactions(Guid accountId);

    /// <summary>
    /// Saves all account data persistently. 
    /// </summary>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task SaveAccounts();
}