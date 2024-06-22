namespace EnergyXChain.API.Transactions.Domain.Models;

public class Sale
{
    public int Id { get; set; }
    public long Amount { get; set; }
    public DateTime Date {  get; set; }
    public bool State {  get; set; }

    public int CustomerId { get; set; }
    public Customer Customer { get; set; }

    public int PlanId { get; set; }
    public Plan Plan { get; set; }
}