using HBBank.Domain;

namespace HBBank.Interfaces;

public interface IAccountService
{
    Task <IBankAccount> CreateAccount(string name, AccountType accountType, string currency, decimal initialBalance);
    Task<List<IBankAccount>> GetAccounts();
}