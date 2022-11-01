using Application.DTOs;
using Domain;

namespace Application.Interfaces;

public interface IOrderService
{
    public List<Order> GetAllOrders();

    public Order CreateNewOrder(OrderDTO dto);

    public Order UpdateOrder(int id, Order order);

    public Order DeleteOrder(int id);

    public Order GetOrderById(int id);
}