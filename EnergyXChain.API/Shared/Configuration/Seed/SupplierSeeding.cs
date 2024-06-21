using EnergyXChain.API.Transactions.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EnergyXChain.API.Shared.Configuration.Seed;

public class SupplierSeeding : IEntityTypeConfiguration<Supplier>
{
    public void Configure(EntityTypeBuilder<Supplier> builder)
    {
        builder.HasData(new Supplier
        {
            Id = 1,
            Name = "AAEXEON"
        }, new Supplier
        {
            Id = 2,
            Name = "APC"
        });
    }
}