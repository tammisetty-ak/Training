using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class OrderDetailRepository : BaseRepository<Order_Detail>,  IOrderDetailRepository
{
    public OrderDetailRepository(Order_HistoryDbContext context) : base(context)
    {
    }
}