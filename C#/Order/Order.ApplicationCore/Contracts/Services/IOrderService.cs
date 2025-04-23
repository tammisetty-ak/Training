using API.Models.Request;
using API.Models.Response;

namespace ApplicationCore.Contracts.Services;

public interface IOrderService
{
    OrderResponseModel InsertOrder(OrderRequestModel orderRequestModel);
    
    OrderResponseModel UpdateOrder(OrderRequestModel orderRequestModel, int id);
    
    OrderResponseModel DeleteOrder(int orderId);
    
    OrderResponseModel GetOrder(int orderId);
    
    IEnumerable<OrderResponseModel> GetOrdersByCustomerId(int customerId);
    
    IEnumerable<OrderResponseModel> GetAllOrders();
}