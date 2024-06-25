namespace EnergyXChain.API.Transactions.Domain.Models.Entity;

public class TransactionData
{
    public string? From { get; set; }
    public string? To { get; set; }
    public decimal Value { get; set; }
}