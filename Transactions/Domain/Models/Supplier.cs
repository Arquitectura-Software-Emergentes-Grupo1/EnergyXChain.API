namespace EnergyXChain.API.Transactions.Domain.Models;

public class Supplier
{
    public int Id { get; set; }
    public string? Uid { get; set; }
    public string? Email { get; set; }
    public string? Password {  get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Phone {  get; set; }

    public IList<Plan> Plans { get; set; }
}