using API.Models.Request;
using API.Models.Response;
using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;

namespace Infrastructure.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    
    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }
    
    public OrderResponseModel InsertOrder(OrderRequestModel orderRequestModel)
    {
        var order = new Order
        {
            CustomerId             = orderRequestModel.CustomerId,
            CustomerName           = orderRequestModel.CustomerName,
            PaymentMethodId        = orderRequestModel.PaymentMethodId,
            PaymentMethodName      = orderRequestModel.PaymentMethodName,
            ShippingMethod         = orderRequestModel.ShippingMethod,
            ShippingMethodAddress  = orderRequestModel.ShippingMethodAddress,
            BillAmount             = orderRequestModel.BillAmount,
            Order_Status           = orderRequestModel.Order_Status,
            Order_Date             = orderRequestModel.Order_Date,
        };
        return MapToResponse(_orderRepository.Insert(order));
    }

    public OrderResponseModel UpdateOrder(OrderRequestModel orderRequestModel, int id)
    {
        var order = new Order
        {
            Id = id,
            CustomerId             = orderRequestModel.CustomerId,
            CustomerName           = orderRequestModel.CustomerName,
            PaymentMethodId        = orderRequestModel.PaymentMethodId,
            PaymentMethodName      = orderRequestModel.PaymentMethodName,
            ShippingMethod         = orderRequestModel.ShippingMethod,
            ShippingMethodAddress  = orderRequestModel.ShippingMethodAddress,
            BillAmount             = orderRequestModel.BillAmount,
            Order_Status           = orderRequestModel.Order_Status,
            Order_Date             = orderRequestModel.Order_Date,
        };
        return MapToResponse(_orderRepository.Update(order));
    }

    public OrderResponseModel DeleteOrder(int orderId)
    {
        return MapToResponse(_orderRepository.Delete(orderId));
    }

    public OrderResponseModel GetOrder(int orderId)
    {
        return MapToResponse(_orderRepository.Get(orderId));
    }

    public IEnumerable<OrderResponseModel> GetOrdersByCustomerId(int customerId)
    {
        var orders = _orderRepository.GetOrdersByCustomerId(customerId);
        foreach (var order in orders)
        {
            yield return MapToResponse(order);
        }
    }

    public IEnumerable<OrderResponseModel> GetAllOrders()
    {
        var  orders = _orderRepository.GetAll();
        foreach (var order in orders)
        {
            yield return MapToResponse(order);
        }
    }
    
    private OrderResponseModel MapToResponse(Order order)
    {
        return new OrderResponseModel()
        {
            Id = order.Id,
            CustomerId = order.CustomerId,
            CustomerName = order.CustomerName,
            PaymentMethodId = order.PaymentMethodId,
            PaymentMethodName = order.PaymentMethodName,
            ShippingMethodAddress = order.ShippingMethodAddress,
            ShippingMethod = order.ShippingMethod,
            BillAmount = order.BillAmount,
            Order_Status = order.Order_Status,
            Order_Date = order.Order_Date,
        };
    }
}