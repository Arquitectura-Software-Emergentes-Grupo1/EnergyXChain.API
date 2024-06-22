namespace EnergyXChain.API.Transactions.Resources.Create;

public class CreateSaleResource
{
    public long Amount { get; set; }
    public bool State { get; set; }
    public int CustomerId { get; set; }
    public int PlanId { get; set; }
}
