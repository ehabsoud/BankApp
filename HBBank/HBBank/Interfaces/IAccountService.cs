using HB_Bank.Domain;

namespace HB_Bank.Interfaces;

public interface IAccountService
{
    IBankAccount CreateAccount(string name, AccountType accountType, string currency, decimal initialBalance);
    List<IBankAccount> GetAccounts();
}