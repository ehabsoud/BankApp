namespace HBBank.Domain;

/// <summary>
/// Represents a transaction on a bank account.
/// A transaction can be a deposit, withdrawal, or transfer,
/// and tracks the amount and account balance before and after the transaction.
/// </summary>
public class Transaction
{
    // Gets or sets the unique identifier of the transaction.
    public Guid Id { get; set; } = Guid.NewGuid();

    // Gets or sets the ID of the account affected by the transaction.
    public Guid AccountId { get; set; }


    // Gets or sets the destination account ID for transfer transactions.
    public Guid? ToAccountId { get; set; }

    // Gets or sets the transaction amount.    
    public decimal Amount { get; set; }

    // Gets or sets the type of transaction (e.g., Deposit, Withdraw, Transfer).
    public string Type { get; set; }

    // Gets or sets the date and time when the transaction occurred.
    public DateTime Date { get; set; } = DateTime.Now;

    // Gets or sets the account balance before the transaction.
    public decimal BalanceBefore { get; set; }

    // Gets or sets the account balance after the transaction.
    public decimal BalanceAfter { get; set; }
}