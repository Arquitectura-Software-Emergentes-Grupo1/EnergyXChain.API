using AutoMapper;
using EnergyXChain.API.Transactions.Domain.Models;
using EnergyXChain.API.Transactions.Resources.Show;

namespace EnergyXChain.API.Transactions.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        // Supplier
        CreateMap<Supplier, SupplierResource>();
    }
}
