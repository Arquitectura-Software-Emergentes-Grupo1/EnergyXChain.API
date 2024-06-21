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

        // Customer
        CreateMap<Customer, CustomerResource>();

        // Plan
        CreateMap<Plan, PlanResource>();

        //Sale
        CreateMap<Sale, SaleResource>()
            .ForMember(dest => dest.Supplier, opt => opt.MapFrom(src => src.Supplier))
            .ForMember(dest => dest.Customer, opt => opt.MapFrom(src => src.Customer))
            .ForMember(dest => dest.Plan, opt => opt.MapFrom(src => src.Plan));
    }
}
