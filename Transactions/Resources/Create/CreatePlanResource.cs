namespace EnergyXChain.API.Transactions.Resources.Create;

public class CreatePlanResource
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public long Fee { get; set; }
    public int SupplierId { get; set; }
}
