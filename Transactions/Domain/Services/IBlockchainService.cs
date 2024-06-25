using EnergyXChain.API.Transactions.Domain.Models.Entity;
using EnergyXChain.API.Transactions.Domain.Services.Communication;

namespace EnergyXChain.API.Transactions.Domain.Services;

public interface IBlockchainService
{
    Task<BlockchainResponse> MakeTransaction(TransactionData transactionData);
}