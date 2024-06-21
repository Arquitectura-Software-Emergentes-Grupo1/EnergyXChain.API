using AutoMapper;
using EnergyXChain.API.Transactions.Domain.Models;
using EnergyXChain.API.Transactions.Resources.Create;

namespace EnergyXChain.API.Transactions.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        // Supplier
        CreateMap<CreateSupplierResource, Supplier>();

        // Customer
        CreateMap<CreateCustomerResource, Customer>();

        // Plan
        CreateMap<CreatePlanResource, Plan>();
    }
}