using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;

namespace Infrastructure.Services;

public class OrderDetailService : IOrderDetailService
{
    private readonly IOrderDetailRepository _orderDetailRepository;
    
    public OrderDetailService(IOrderDetailRepository orderDetailRepository)
    {
        _orderDetailRepository = orderDetailRepository;
    }
}