using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Infrastructure.Data;

public class Order_HistoryDbContext: DbContext
{
    public Order_HistoryDbContext(DbContextOptions<Order_HistoryDbContext> options): base(options)
    {
        
    }
    
    public DbSet<Order_Detail> Order_Details { get; set; }
    public DbSet<Order> Orders { get; set; }
}