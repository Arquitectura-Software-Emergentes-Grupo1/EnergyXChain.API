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
        modelBuilder.Entity<Supplier>().Property(supplier => supplier.Id);
        modelBuilder.Entity<Supplier>().Property(supplier => supplier.Uid);
        modelBuilder.Entity<Supplier>().Property(supplier => supplier.Email);
        modelBuilder.Entity<Supplier>().Property(supplier => supplier.WalletAddress);
        modelBuilder.Entity<Supplier>().Property(supplier => supplier.Name);
        modelBuilder.Entity<Supplier>().Property(supplier => supplier.Description);
        modelBuilder.Entity<Supplier>().Property(supplier => supplier.Phone);
        modelBuilder.Entity<Supplier>()
            .HasMany(supplier => supplier.Plans)
            .WithOne(plan => plan.Supplier)
            .HasForeignKey(plan => plan.SupplierId)
            .HasConstraintName("FkSupplierId");

        // TransactionCustomer
        modelBuilder.Entity<Customer>().ToTable("Customers");
        modelBuilder.Entity<Customer>().HasKey(customer => customer.Id);
        modelBuilder.Entity<Customer>().Property(customer => customer.Id);
        modelBuilder.Entity<Customer>().Property(customer => customer.Uid);
        modelBuilder.Entity<Customer>().Property(customer => customer.WalletAddress);
        modelBuilder.Entity<Customer>().Property(customer => customer.Email);
        modelBuilder.Entity<Customer>().Property(customer => customer.Name);
        modelBuilder.Entity<Customer>().Property(customer => customer.Phone);
        modelBuilder.Entity<Customer>().Property(customer => customer.Age);
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
        modelBuilder.Entity<Plan>().Property(plan => plan.Description);
        modelBuilder.Entity<Plan>().Property(plan => plan.Fee);
        modelBuilder.Entity<Plan>().Property(plan => plan.SupplierId);
        modelBuilder.Entity<Plan>()
            .HasMany(plan => plan.Sales)
            .WithOne(sale => sale.Plan)
            .HasForeignKey(sale => sale.PlanId)
            .HasConstraintName("FkPlanId");

        // TransactionSale
        modelBuilder.Entity<Sale>().ToTable("Sales");
        modelBuilder.Entity<Sale>().HasKey(sale => sale.Id);
        modelBuilder.Entity<Sale>().Property(sale => sale.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<Sale>().Property(sale => sale.Amount);
        modelBuilder.Entity<Sale>().Property(sale => sale.Date);
        modelBuilder.Entity<Sale>().Property(sale => sale.State);
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