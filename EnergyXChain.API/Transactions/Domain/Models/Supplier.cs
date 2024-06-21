namespace EnergyXChain.API.Transactions.Domain.Models;

public class Supplier
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public IList<Sale> Sales { get; set; }
}