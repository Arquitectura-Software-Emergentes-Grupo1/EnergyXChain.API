﻿namespace EnergyXChain.API.Transactions.Resources.Show;

public class PlanResource
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public long Fee { get; set; }
    public int SupplierId { get; set; }
}