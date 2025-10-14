using HBBank.Domain;

namespace HBBank.Services;

public class AccountService : IAccountService
{
    private const string AccountKey = "hbbank.accounts";
    private const string TransactionKey = "hbbank.transactions";

    private readonly List<IBankAccount> _accounts = new();
    private readonly List<Transaction> _transactions = new();
    private readonly IStorageService _storageService;

    private bool isLoaded;
    public AccountService(IStorageService storageService) => _storageService = storageService;

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

    private Task SaveAsync()
    {
        var saveAccounts = _storageService.SetItemAsync(AccountKey, _accounts);
        var saveTransactions = _storageService.SetItemAsync(TransactionKey, _transactions);
        return Task.WhenAll(saveAccounts, saveTransactions);
    }
    public async Task<IBankAccount> CreateAccount(string name, AccountType accountType, string currency,
        decimal initialBalance)
    {
        await IsInitialized();
        var account = new BankAccount(name, accountType, currency, initialBalance);
        _accounts.Add(account);
        await SaveAsync();
        return account;
    }
    public async Task<List<IBankAccount>> GetAccounts()
    {
        await IsInitialized();
        return _accounts.Cast<IBankAccount>().ToList();
    }

    public async Task AddTransaction(Transaction transaction)
    {
        await IsInitialized();
        _transactions.Add(transaction);
        await SaveAsync();
    }

    public async Task<List<Transaction>> GetTransactions(Guid accountId)
    {
        await IsInitialized();
        return _transactions
            .Where(t => t.AccountId == accountId || t.ToAccountId == accountId)
            .ToList();
    }

    public async Task SaveAccounts()
    {
        await SaveAsync();
    }
}