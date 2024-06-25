namespace EnergyXChain.API.Transactions.Resources.Create;

public class CreateCustomerResource
{
    public int Id { get; set; }
    public string? Uid { get; set; }
    public string? Email { get; set; }
    public string? Name { get; set; }
    public string? Phone { get; set; }
    public string? Age { get; set; }
    public string? WalletAddress { get; set; }
}