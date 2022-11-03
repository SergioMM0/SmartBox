using Application.Interfaces;
using Domain;

namespace Infrastructure;

public class OrderRepository : IOrderRepository
{
    private readonly SmartBoxContext _context;
    
    public OrderRepository(SmartBoxContext context)
    {
        _context = context;
    }
    
    public List<Order> GetAllOrders()
    {
        return _context.OrdersTable.ToList();
    }

    public Order CreateNewOrder(Order order)
    {
       _context.OrdersTable.Add(order);
       _context.SaveChanges();
       return order;
    }

    public Order UpdateOrder(Order order)
    {
        var orderToUpdate = _context.OrdersTable.Find(order.Id) ?? throw new KeyNotFoundException();
        orderToUpdate.DeliveryAddress = order.DeliveryAddress;
        _context.OrdersTable.Attach(orderToUpdate);
        _context.SaveChanges();
        return order;
    }

    public Order DeleteOrder(int id)
    {
        var orderToDelete = _context.OrdersTable.Find(id) ?? throw new KeyNotFoundException();
        _context.OrdersTable.Remove(orderToDelete);
        _context.SaveChanges();
        return orderToDelete;
    }

    public Order GetOrderById(int id)
    {
        return _context.OrdersTable.Find(id) ?? throw new KeyNotFoundException();
    }
}