namespace EnergyXChain.API.Transactions.Domain.Models;

public class Plan
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public long Fee { get; set; }
    public int SupplierId { get; set; }
    public Supplier Supplier { get; set; }

    public IList<Sale> Sales { get; set; }
}