using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain;
using FluentValidation;


namespace Application;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _repository;
    private readonly IMapper _mapper;
    //private readonly IValidator<OrderDTO> _validator;

    public OrderService(
        IOrderRepository repository,
        IMapper mapper//,
        //IValidator<OrderDTO> validator
        ) 
    {
        _mapper = mapper;
        _repository = repository;
        //_validator = validator;
    }
    
    public List<Order> GetAllOrders()
    {
        return _repository.GetAllOrders();
    }

    public Order CreateNewOrder(OrderDTO dto)
    {
        /*
        var validation = _validator.Validate(dto);
        if (!validation.IsValid)
        {
            throw new ValidationException(validation.ToString());
        }
        
        wtf?xd Why this validator is giving problems?
        */
        return _repository.CreateNewOrder(_mapper.Map<Order>(dto));
    }

    public Order UpdateOrder(int id, Order order)
    {
        if (id != order.Id)
        {
            throw new ValidationException("ID in body and route are different");
        }
        return _repository.UpdateOrder(order);
    }

    public Order DeleteOrder(int id)
    {
        return _repository.DeleteOrder(id);
    }

    public Order GetOrderById(int id)
    {
        return _repository.GetOrderById(id);
    }
}