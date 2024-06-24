namespace EnergyXChain.API.Transactions.Domain.Models;

public class Customer
{
    public int Id { get; set; }
    public string? Uid { get; set; }
    public string? Email { get; set; }
    public string? Name { get; set; }
    public string? Phone {  get; set; }
    public string? Age {  get; set; }

    public IList<Sale> Sales { get; set; }
}