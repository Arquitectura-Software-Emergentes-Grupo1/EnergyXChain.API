using EnergyXChain.API.Transactions.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EnergyXChain.API.Shared.Configuration.Seed;

public class CustomerSeeding : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasData(new Customer
        {
            Id = 1,
            Name = "Marzzio"
        }, new Customer
        {
            Id = 2,
            Name = "Leonardo"
        });
    }
}