using EnergyXChain.API.Shared.Configuration.Seed;
using EnergyXChain.API.Shared.Extensions;
using EnergyXChain.API.Transactions.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EnergyXChain.API.Shared.Persistence.Contexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Sale> Sales { get; set; }
    public DbSet<Plan> Plans { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // TransactionSupllier
        modelBuilder.Entity<Supplier>().ToTable("Suppliers");
        modelBuilder.Entity<Supplier>().HasKey(supplier => supplier.Id);
        modelBuilder.Entity<Supplier>().Property(supplier => supplier.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<Supplier>().Property(supplier => supplier.Name);
        modelBuilder.Entity<Supplier>()
            .HasMany(supplier => supplier.Sales)
            .WithOne(sale => sale.Supplier)
            .HasForeignKey(sale => sale.SupplierId)
            .HasConstraintName("FkSupplierId");

        // TransactionCustomer
        modelBuilder.Entity<Customer>().ToTable("Customers");
        modelBuilder.Entity<Customer>().HasKey(customer => customer.Id);
        modelBuilder.Entity<Customer>().Property(customer => customer.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<Customer>().Property(customer => customer.Name);
        modelBuilder.Entity<Customer>()
            .HasMany(customer => customer.Sales)
            .WithOne(sale => sale.Customer)
            .HasForeignKey(sale => sale.CustomerId)
            .HasConstraintName("FkCustomerId");

        // Plan
        modelBuilder.Entity<Plan>().ToTable("Plans");
        modelBuilder.Entity<Plan>().HasKey(plan => plan.Id);
        modelBuilder.Entity<Plan>().Property(plan => plan.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<Plan>().Property(plan => plan.Name);
        modelBuilder.Entity<Plan>()
            .HasMany(plan => plan.Sales)
            .WithOne(sale => sale.Plan)
            .HasForeignKey(sale => sale.PlanId)
            .HasConstraintName("FkPlanId");

        // TransactionSale
        modelBuilder.Entity<Sale>().ToTable("Sales");
        modelBuilder.Entity<Sale>().HasKey(sale => sale.Id);
        modelBuilder.Entity<Sale>().Property(sale => sale.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<Sale>().Property(sale => sale.SupplierId);
        modelBuilder.Entity<Sale>().Property(sale => sale.CustomerId);
        modelBuilder.Entity<Sale>().Property(sale => sale.PlanId);
        /*
        modelBuilder.Entity<Sale>()
            .HasOne(sale => sale.Supplier)
            .WithMany(supplier => supplier.Sales)
            .HasForeignKey(sale => sale.SupplierId)
            .HasConstraintName("FkSalesTransactionSupplierId");
        modelBuilder.Entity<Sale>()
            .HasOne(sale => sale.Customer)
            .WithMany(customer => customer.Sales)
            .HasForeignKey(sale => sale.CustomerId)
            .HasConstraintName("FkSalesTransactionCustomerId");
        modelBuilder.Entity<Sale>()
            .HasOne(sale => sale.Plan)
            .WithMany(plan => plan.Sales)
            .HasForeignKey(sale => sale.PlanId)
            .HasConstraintName("FkSalesPlanId");
        */

        // Seeding
        modelBuilder.ApplyConfiguration(new SupplierSeeding());
        modelBuilder.ApplyConfiguration(new CustomerSeeding());
        modelBuilder.ApplyConfiguration(new PlanSeeding());

        // SnakeCase
        modelBuilder.ConvertAllToSnakeCase();
    }
}