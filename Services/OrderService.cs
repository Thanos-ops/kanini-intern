using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Foodapi.Data;
using Foodapi.DTOs;

namespace Foodapi.Services;

public class OrderService : IOrderService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public OrderService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<OrderDto>> GetOrdersAsync(int userId, int page = 1, int pageSize = 10)
    {
        var orders = await _context.Orders
            .Include(o => o.Restaurant)
            .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.MenuItem)
            .Where(o => o.UserId == userId)
            .OrderByDescending(o => o.CreatedAt)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return _mapper.Map<List<OrderDto>>(orders);
    }

    public async Task<OrderDto?> GetOrderByIdAsync(int userId, int orderId)
    {
        var order = await _context.Orders
            .Include(o => o.Restaurant)
            .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.MenuItem)
            .FirstOrDefaultAsync(o => o.OrderId == orderId && o.UserId == userId);
        
        return order == null ? null : _mapper.Map<OrderDto>(order);
    }
}