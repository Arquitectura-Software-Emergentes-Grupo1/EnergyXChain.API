using EnergyXChain.API.Transactions.Domain.Models.Entity;

namespace EnergyXChain.API.Transactions.Domain.Services.Communication;

public class BlockchainResponse
{
    public string? Message { get; set; }
    public TransactionData? TransactionData { get; set; }
    public string? TransactionHash { get; set; }

    public BlockchainResponse(TransactionData? transactionData, string? transactionHash)
    {
        TransactionData = transactionData;
        TransactionHash = transactionHash;
    }

    public BlockchainResponse(string? message)
    {
        Message = message;
    }
}