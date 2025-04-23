using ApplicationCore.Entities;

namespace ApplicationCore.Contracts.Repositories;

public interface IOrderRepository : IRepository<Order>
{
    public IEnumerable<Order> GetOrdersByCustomerId(int customerId);
}