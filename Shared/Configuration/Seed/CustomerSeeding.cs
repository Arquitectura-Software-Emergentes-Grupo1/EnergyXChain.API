using EnergyXChain.API.Transactions.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EnergyXChain.API.Shared.Configuration.Seed;

public class CustomerSeeding : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasData(
            new Customer
            {
                Id = 1,
                Email = "john.doe@example.com",
                Password = "password123",
                Name = "John Doe",
                Phone = "123-456-7890",
                Age = "30"
            },
            new Customer
            {
                Id = 2,
                Email = "jane.smith@example.com",
                Password = "password456",
                Name = "Jane Smith",
                Phone = "987-654-3210",
                Age = "25"
            },
            new Customer
            {
                Id = 3,
                Email = "alice.jones@example.com",
                Password = "password789",
                Name = "Alice Jones",
                Phone = "555-666-7777",
                Age = "28"
            },
            new Customer
            {
                Id = 4,
                Email = "bob.brown@example.com",
                Password = "password101",
                Name = "Bob Brown",
                Phone = "444-555-6666",
                Age = "35"
            },
            new Customer
            {
                Id = 5,
                Email = "carol.white@example.com",
                Password = "password202",
                Name = "Carol White",
                Phone = "222-333-4444",
                Age = "32"
            }
        );
    }
}