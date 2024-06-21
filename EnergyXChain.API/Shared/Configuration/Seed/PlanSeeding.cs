using EnergyXChain.API.Transactions.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EnergyXChain.API.Shared.Configuration.Seed;

public class PlanSeeding : IEntityTypeConfiguration<Plan>
{
    public void Configure(EntityTypeBuilder<Plan> builder)
    {
        builder.HasData(new Plan
        {
            Id = 1,
            Name = "Plan basico"
        }, new Plan
        {
            Id = 2,
            Name = "Plan intermedio"
        }, new Plan
        {
            Id = 3,
            Name = "Plan maximo"
        });
    }
}
