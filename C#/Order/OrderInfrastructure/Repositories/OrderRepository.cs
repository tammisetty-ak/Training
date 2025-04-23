using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class OrderRepository : BaseRepository<Order>, IOrderRepository
{
    
    private readonly Order_HistoryDbContext _orderHistoryDbContext;
    
    public OrderRepository(Order_HistoryDbContext context) : base(context)
    {
        _orderHistoryDbContext = context;
    }

    public IEnumerable<Order> GetOrdersByCustomerId(int customerId)
    {
        return _orderHistoryDbContext.Orders.Where(o => o.CustomerId == customerId).ToList();
    }
}