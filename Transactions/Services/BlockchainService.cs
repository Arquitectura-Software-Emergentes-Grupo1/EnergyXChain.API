using EnergyXChain.API.Transactions.Domain.Models.Entity;
using EnergyXChain.API.Transactions.Domain.Services;
using EnergyXChain.API.Transactions.Domain.Services.Communication;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Web3;

namespace EnergyXChain.API.Transactions.Services;

public class BlockchainService : IBlockchainService
{
    private readonly Web3 _web3;
    public BlockchainService()
    {
        _web3 = new Web3("http://127.0.0.1:8545");
    }
    public async Task<BlockchainResponse> MakeTransaction(TransactionData transactionData)
    {
        var transactionHash = await _web3.Eth.Transactions.SendTransaction.SendRequestAsync(new TransactionInput
        {
            From = transactionData.From,
            To = transactionData.To,
            Value = new Nethereum.Hex.HexTypes.HexBigInteger(Web3.Convert.ToWei(transactionData.Value))
        });
        return new BlockchainResponse(transactionData, transactionHash);
    }
}