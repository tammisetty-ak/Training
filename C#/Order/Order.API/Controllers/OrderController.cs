using API.Models.Request;
using ApplicationCore.Contracts.Services;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class OrderController : Controller
{
    private readonly IOrderService _orderService;
    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }
    // GET
    [HttpGet]
    public IActionResult GetAllOrders()
    {
        return Ok(_orderService.GetAllOrders());
    }

    [HttpPost]
    public IActionResult SaveOrder(OrderRequestModel orderRequestModel)
    {
        return Ok(_orderService.InsertOrder(orderRequestModel));
    }

    [HttpGet]
    public IActionResult GetOrderByCustomerId(int customerId)
    {
        return Ok(_orderService.GetOrdersByCustomerId(customerId));
    }

    [HttpDelete]
    public IActionResult DeleteOrder(int orderId)
    {
        return Ok(_orderService.DeleteOrder(orderId));
    }

    [HttpPut]
    public IActionResult UpdateOrder(OrderRequestModel orderRequestModel, int orderId)
    {
        return Ok(_orderService.UpdateOrder(orderRequestModel,  orderId));
    }
}