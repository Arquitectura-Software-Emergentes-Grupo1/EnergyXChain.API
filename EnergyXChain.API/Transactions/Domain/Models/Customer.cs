namespace EnergyXChain.API.Transactions.Domain.Models;

public class Customer
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public IList<Sale> Sales { get; set; }
}