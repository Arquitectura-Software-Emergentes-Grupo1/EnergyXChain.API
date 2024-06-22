namespace EnergyXChain.API.Transactions.Resources.Show;

public class SaleResource
{
    public int Id { get; set; }
    public long Amount { get; set; }
    public DateTime Date { get; set; }
    public bool State { get; set; }
    public int CustomerId { get; set; }
    public int PlanId { get; set; }
}