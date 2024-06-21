namespace EnergyXChain.API.Transactions.Resources.Show;

public class SaleResource
{
    public int Id { get; set; }
    public int SupplierId { get; set; }
    public SupplierResource Supplier { get; set; }
    public int CustomerId { get; set; }
    public CustomerResource Customer { get; set; }
    public int PlanId { get; set; }
    public PlanResource Plan { get; set; }
}