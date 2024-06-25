using EnergyXChain.API.Shared.Domain.Repositories;
using EnergyXChain.API.Shared.Persistence.Contexts;
using EnergyXChain.API.Shared.Persistence.Repositories;
using EnergyXChain.API.Transactions.Domain.Models;
using EnergyXChain.API.Transactions.Domain.Repositories;
using EnergyXChain.API.Transactions.Domain.Services;
using EnergyXChain.API.Transactions.Mapping;
using EnergyXChain.API.Transactions.Persistence.Repositories;
using EnergyXChain.API.Transactions.Service;
using EnergyXChain.API.Transactions.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// OpenAPI Configuration
builder.Services.AddSwaggerGen(
    options =>
    {
        options.SwaggerDoc("v0", new OpenApiInfo
        {
            Version = "v1",
            Title = "EnergyXChain.API",
            Description = "EnergyXChain.API v0. Resources Management 💎"
        });
        options.EnableAnnotations();
    }
);

// Connection String
var connectionString = builder.Configuration.GetConnectionString("EnergyXChainDbConnection");

// Add DbContext
builder.Services.AddDbContext<AppDbContext>(optionsBuilder =>
{
    if (connectionString != null)
    {
        optionsBuilder.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 35)))
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors();
    }
});

builder.Services.AddRouting(options => options.LowercaseUrls = true);

// CORS
builder.Services.AddCors();

// Transaction Services
builder.Services.AddScoped<ISupplierRepository, SupplierRepository>();
builder.Services.AddScoped<IBaseRepository<Supplier, int>, SupplierRepository>();
builder.Services.AddScoped<ISupplierService, SupplierService>();

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IBaseRepository<Customer, int>, CustomerRepository>();
builder.Services.AddScoped<ICustomerService, CustomerService>();

builder.Services.AddScoped<IPlanRepository, PlanRepository>();
builder.Services.AddScoped<IBaseRepository<Plan, int>, PlanRepository>();
builder.Services.AddScoped<IPlanService, PlanService>();

builder.Services.AddScoped<ISaleRepository, SaleRepository>();
builder.Services.AddScoped<IBaseRepository<Sale, int>, SaleRepository>();
builder.Services.AddScoped<ISaleService, SaleService>();

builder.Services.AddScoped<IBlockchainService, BlockchainService>();

// Shared Services
// -- Unit Of Work
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Automapper Services
builder.Services.AddAutoMapper(
    typeof(ModelToResourceProfile),
    typeof(ResourceToModelProfile),
    typeof(EnergyXChain.API.Transactions.Mapping.ModelToResourceProfile),
    typeof(EnergyXChain.API.Transactions.Mapping.ResourceToModelProfile));

var app = builder.Build();
app.UseStaticFiles(); // To use dark swagger styles.

// Validation for ensuring database tables were created.
using (var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<AppDbContext>())
{
    // context?.Database.EnsureCreated();
    context?.Database.EnsureDeleted();
    context?.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("v0/swagger.json", "v0");
        options.InjectStylesheet("/swagger-ui/dark-swagger.css");
        options.RoutePrefix = "swagger";
    });
// }

app.UseCors(policyBuilder => policyBuilder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();