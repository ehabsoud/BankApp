using HBBank.Domain;

namespace HBBank.Services;

/// <summary>
/// Service class responsible for managing bank accounts and transactions.
/// Handles creating accounts, retrieving data, saving to persistent storage, and adding transactions.
/// </summary>
public class AccountService : IAccountService
{
    // Storage keys used to identify data in persistent storage.
    private const string AccountKey = "hbbank.accounts";
    private const string TransactionKey = "hbbank.transactions";

    // Internal lists to hold accounts and transactions in memory.
    private readonly List<IBankAccount> _accounts = new();
    private readonly List<Transaction> _transactions = new();

    // Reference to the storage service for loading and saving data.
    private readonly IStorageService _storageService;

    // Flag to indicate whether data has already been loaded from storage.
    private bool isLoaded;

    /// <summary>
    /// Initializes a new instance of the <see cref="AccountService"/> class.
    /// </summary>
    /// <param name="storageService">An instance of <see cref="IStorageService"/> used for data persistence</param>
    public AccountService(IStorageService storageService) => _storageService = storageService;

    /// <summary>
    /// Ensures that account and transaction data are loaded from storage.
    /// Called automatically before performing any operations.
    /// </summary>
    private async Task IsInitialized()
    {
        if (isLoaded) return;

        var fromStorage = await _storageService.GetItemAsync<List<BankAccount>>(AccountKey);
        _accounts.Clear();
        if (fromStorage is { Count: > 0 })
            _accounts.AddRange(fromStorage);
        var transFromStorage = await _storageService.GetItemAsync<List<Transaction>>(TransactionKey);
        _transactions.Clear();
        if (transFromStorage is { Count: > 0 })
            _transactions.AddRange(transFromStorage);
        isLoaded = true;
    }

    /// <summary>
    /// Saves all accounts and transactions to persistent storage.
    /// Returns a <see cref="Task"/> that completes when both save operations have finished.
    /// </summary>
    private Task SaveAsync()
    {
        var saveAccounts = _storageService.SetItemAsync(AccountKey, _accounts);
        var saveTransactions = _storageService.SetItemAsync(TransactionKey, _transactions);
        return Task.WhenAll(saveAccounts, saveTransactions);
    }

    /// <summary>
    /// Creates a new bank account and saves it to storage.
    /// </summary>
    /// <param name="name">The name of the account holder.</param>
    /// <param name="accountType">The type of account (e.g., Savings, Deposit).</param>
    /// <param name="currency">The currency used for the account.</param>
    /// <param name="initialBalance">The starting balance of the account.</param>
    /// <returns>A newly created <see cref="IBankAccount"/> object.</returns>
    public async Task<IBankAccount> CreateAccount(string name, AccountType accountType, string currency,
        decimal initialBalance)
    {
        await IsInitialized();
        var account = new BankAccount(name, accountType, currency, initialBalance);
        _accounts.Add(account);
        await SaveAsync();
        return account;
    }

    /// <summary>
    /// Retrieves all existing bank accounts.
    /// Applies interest to savings accounts before returning the list.
    /// If any balances change due to interest, the accounts are saved to storage.
    /// </summary>
    /// <returns>A list of <see cref="IBankAccount"/> objects with updated balances.</returns>
    public async Task<List<IBankAccount>> GetAccounts()
    {
        await IsInitialized();

        bool anyChanged = false;

        foreach (var account in _accounts.OfType<BankAccount>())
        {
            decimal oldBalance = account.Balance;
            account.ApplyInterest();
            if (account.Balance != oldBalance)
                anyChanged = true;
        }

        if (anyChanged)
        {
            await SaveAsync();
        }

        return _accounts.Cast<IBankAccount>().ToList();
    }

    /// <summary>
    /// Adds a new transaction and saves it to storage.
    /// </summary>
    /// <param name="transaction">The transaction to be added.</param>
    public async Task AddTransaction(Transaction transaction)
    {
        await IsInitialized();
        _transactions.Add(transaction);
        await SaveAsync();
    }

    /// <summary>
    /// Retrieves all transactions related to a specific account.
    /// </summary>
    /// <param name="accountId">The unique identifier of the account.</param>
    /// <returns>A list of <see cref="Transaction"/> objects linked to the account.</returns>
    public async Task<List<Transaction>> GetTransactions(Guid accountId)
    {
        await IsInitialized();
        return _transactions
            .Where(t => t.AccountId == accountId || t.ToAccountId == accountId)
            .ToList();
    }

    /// <summary>
    /// Manually saves all account and transaction data to storage.
    /// </summary>
    public async Task SaveAccounts()
    {
        await SaveAsync();
    }
}