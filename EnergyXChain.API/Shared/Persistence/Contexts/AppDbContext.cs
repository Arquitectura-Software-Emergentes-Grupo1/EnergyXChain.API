using EnergyXChain.API.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

namespace EnergyXChain.API.Shared.Persistence.Contexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // SnakeCase
        modelBuilder.ConvertAllToSnakeCase();
    }
}