namespace HBBank.Domain;

/// <summary>
/// Represents a transaction on a bank account.
/// A transaction can be a deposit, withdrawal, or transfer,
/// and tracks the amount and account balance before and after the transaction.
/// </summary>
public class Transaction
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid AccountId { get; set; }
    public Guid? ToAccountId { get; set; }
    public decimal Amount { get; set; }
    public string Type { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;

    public decimal BalanceBefore { get; set; }
    public decimal BalanceAfter { get; set; }
}