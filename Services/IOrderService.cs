using Foodapi.DTOs;

namespace Foodapi.Services;

public interface IOrderService
{
    Task<List<OrderDto>> GetOrdersAsync(int userId, int page = 1, int pageSize = 10);
    Task<OrderDto?> GetOrderByIdAsync(int userId, int orderId);
}