using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class OrderController : Controller
{
    // GET
    [HttpGet]
    public IActionResult GetAllOrders()
    {
        return Ok("GetAllOrders");
    }

    [HttpPost]
    public IActionResult SaveOrder()
    {
        return Ok("SaveOrder");
    }

    [HttpGet]
    public IActionResult GetOrderByCustomerId(int customerId)
    {
        return Ok("GetOrderByCustomerId");
    }

    [HttpDelete]
    public IActionResult DeleteOrder()
    {
        return Ok("DeleteOrder");
    }

    [HttpPut]
    public IActionResult UpdateOrder()
    {
        return Ok("UpdateOrder");
    }
}