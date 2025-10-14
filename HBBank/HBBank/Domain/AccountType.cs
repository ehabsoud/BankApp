using System.ComponentModel.DataAnnotations;

namespace HBBank.Domain;

public enum AccountType
{
    Unknown = 0,
    
    Savings = 1,
    
    Deposit = 2
}