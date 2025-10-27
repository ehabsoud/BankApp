using System.ComponentModel.DataAnnotations;

namespace HBBank.Domain;

// Represents the account types supported in the system.
public enum AccountType
{
    Unknown = 0,

    Savings = 1,

    Deposit = 2
}