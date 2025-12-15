using Microsoft.AspNetCore.Mvc;
using Foodapi.Services;
using Foodapi.DTOs;

namespace Foodapi.Controllers;

[Route("api/user/[controller]")]
[ApiController]

public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    private int GetUserId()
    {
        return 2; // Default user ID for testing
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<List<OrderDto>>>> GetOrders([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
    {
        var orders = await _orderService.GetOrdersAsync(GetUserId(), page, pageSize);
        return Ok(ApiResponse<List<OrderDto>>.SuccessResponse(orders));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<OrderDto>>> GetOrder(int id)
    {
        var order = await _orderService.GetOrderByIdAsync(GetUserId(), id);
        return order == null
            ? Ok(ApiResponse<OrderDto>.ErrorResponse("Order not found"))
            : Ok(ApiResponse<OrderDto>.SuccessResponse(order));
    }
}