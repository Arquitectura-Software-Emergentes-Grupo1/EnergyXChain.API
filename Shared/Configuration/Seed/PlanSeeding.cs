using EnergyXChain.API.Transactions.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EnergyXChain.API.Shared.Configuration.Seed;

public class PlanSeeding : IEntityTypeConfiguration<Plan>
{
    public void Configure(EntityTypeBuilder<Plan> builder)
    {
        builder.HasData(
            new Plan
            {
                Id = 1,
                Name = "Basic Plan",
                Fee = 1000,
                SupplierId = 1
            },
            new Plan
            {
                Id = 2,
                Name = "Standard Plan",
                Fee = 1500,
                SupplierId = 1
            },
            new Plan
            {
                Id = 3,
                Name = "Premium Plan",
                Fee = 2000,
                SupplierId = 2
            },
            new Plan
            {
                Id = 4,
                Name = "Eco Plan",
                Fee = 1200,
                SupplierId = 2
            },
            new Plan
            {
                Id = 5,
                Name = "Business Plan",
                Fee = 2500,
                SupplierId = 3
            },
            new Plan
            {
                Id = 6,
                Name = "Green Plan",
                Fee = 1700,
                SupplierId = 3
            },
            new Plan
            {
                Id = 7,
                Name = "Family Plan",
                Fee = 1300,
                SupplierId = 4
            },
            new Plan
            {
                Id = 8,
                Name = "Unlimited Plan",
                Fee = 3000,
                SupplierId = 4
            },
            new Plan
            {
                Id = 9,
                Name = "Small Business Plan",
                Fee = 2200,
                SupplierId = 5
            },
            new Plan
            {
                Id = 10,
                Name = "Enterprise Plan",
                Fee = 3500,
                SupplierId = 5
            }
        );
    }
}