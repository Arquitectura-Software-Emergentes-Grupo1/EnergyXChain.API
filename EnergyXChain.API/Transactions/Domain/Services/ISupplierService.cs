﻿using EnergyXChain.API.Transactions.Domain.Models;
using EnergyXChain.API.Transactions.Domain.Services.Communication;

namespace EnergyXChain.API.Transactions.Domain.Services;

public interface ISupplierService
{
    Task<SupplierResponse> FindAsync(int id);
    Task<SupplierResponse> AddAsync(Supplier newSupplier);
    Task<IEnumerable<Supplier>> ListAllAsync();
}