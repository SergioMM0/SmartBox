using Domain;

namespace Application.Interfaces;

public interface IOrderRepository
{
    public List<Order> GetAllOrders();

    public Order CreateNewOrder(Order order);

    public Order UpdateOrder(Order order);

    public Order DeleteOrder(int id);

    public Order GetOrderById(int id);
}