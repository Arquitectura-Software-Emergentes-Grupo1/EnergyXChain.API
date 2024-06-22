using EnergyXChain.API.Transactions.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EnergyXChain.API.Shared.Configuration.Seed;

public class SupplierSeeding : IEntityTypeConfiguration<Supplier>
{
    public void Configure(EntityTypeBuilder<Supplier> builder)
    {
        builder.HasData(
            new Supplier
            {
                Id = 1,
                Email = "supplier1@example.com",
                Password = "supplierpass1",
                Name = "Supplier One",
                Description = "Supplier One is known for its reliable energy plans.",
                Phone = "123-111-1111"
            },
            new Supplier
            {
                Id = 2,
                Email = "supplier2@example.com",
                Password = "supplierpass2",
                Name = "Supplier Two",
                Description = "Supplier Two offers competitive rates and great customer service.",
                Phone = "123-222-2222"
            },
            new Supplier
            {
                Id = 3,
                Email = "supplier3@example.com",
                Password = "supplierpass3",
                Name = "Supplier Three",
                Description = "Supplier Three specializes in renewable energy sources.",
                Phone = "123-333-3333"
            },
            new Supplier
            {
                Id = 4,
                Email = "supplier4@example.com",
                Password = "supplierpass4",
                Name = "Supplier Four",
                Description = "Supplier Four has a wide variety of plans for businesses.",
                Phone = "123-444-4444"
            },
            new Supplier
            {
                Id = 5,
                Email = "supplier5@example.com",
                Password = "supplierpass5",
                Name = "Supplier Five",
                Description = "Supplier Five is an industry leader with decades of experience.",
                Phone = "123-555-5555"
            }
        );
    }
}