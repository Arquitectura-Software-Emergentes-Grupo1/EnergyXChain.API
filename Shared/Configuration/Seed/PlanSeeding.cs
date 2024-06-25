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
                Description = "An affordable option providing essential energy services for small households.",
                Fee = 1000,
                SupplierId = 1
            },
            new Plan
            {
                Id = 2,
                Name = "Standard Plan",
                Description = "A popular choice offering a balance of cost and features for medium-sized homes.",
                Fee = 1500,
                SupplierId = 1
            },
            new Plan
            {
                Id = 3,
                Name = "Premium Plan",
                Description = "A premium plan providing high-end energy services with additional benefits.",
                Fee = 2000,
                SupplierId = 2
            },
            new Plan
            {
                Id = 4,
                Name = "Eco Plan",
                Description = "An environmentally-friendly option focused on renewable energy sources.",
                Fee = 1200,
                SupplierId = 2
            },
            new Plan
            {
                Id = 5,
                Name = "Business Plan",
                Description = "A comprehensive plan tailored for small businesses with higher energy needs.",
                Fee = 2500,
                SupplierId = 3
            },
            new Plan
            {
                Id = 6,
                Name = "Green Plan",
                Description = "A sustainable plan aimed at reducing carbon footprint with green energy solutions.",
                Fee = 1700,
                SupplierId = 3
            },
            new Plan
            {
                Id = 7,
                Name = "Family Plan",
                Description = "A family-oriented plan designed to accommodate larger households with varied energy usage.",
                Fee = 1300,
                SupplierId = 4
            },
            new Plan
            {
                Id = 8,
                Name = "Unlimited Plan",
                Description = "An all-inclusive plan offering unlimited energy supply for high-demand users.",
                Fee = 3000,
                SupplierId = 4
            },
            new Plan
            {
                Id = 9,
                Name = "Small Business Plan",
                Description = "A cost-effective solution for small businesses, balancing cost and energy needs.",
                Fee = 2200,
                SupplierId = 5
            },
            new Plan
            {
                Id = 10,
                Name = "Enterprise Plan",
                Description = "A high-capacity plan designed for large enterprises with extensive energy requirements.",
                Fee = 3500,
                SupplierId = 5
            }
        );
    }
}