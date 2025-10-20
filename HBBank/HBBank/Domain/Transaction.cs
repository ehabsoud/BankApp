namespace HBBank.Domain;

public class Transaction
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid AccountId { get; set; }          // kontot som påverkas
    public Guid? ToAccountId { get; set; }       // för överföringar
    public decimal Amount { get; set; }          // belopp
    public string Type { get; set; }             // "Deposit", "Withdraw", "Transfer"
    public DateTime Date { get; set; } = DateTime.Now;
    
    public decimal BalanceBefore { get; set; } // saldo före transaktion
    public decimal BalanceAfter { get; set; }    // saldo efter transaktion
}