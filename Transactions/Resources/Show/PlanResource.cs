namespace EnergyXChain.API.Transactions.Resources.Show;

public class PlanResource
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public double Fee { get; set; }
    public SupplierResource Supplier { get; set; }
}
