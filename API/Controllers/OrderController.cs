using Application.DTOs;
using Application.Interfaces;
using Domain;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[AllowAnonymous]
[Route("[controller]")]
public class OrderController : ControllerBase
{
    private IOrderService _service;

    public OrderController(IOrderService service)
    {
        _service = service;
    }

    [HttpGet]
    public ActionResult<List<Order>> GetAllOrders()
    {
        try
        {
            var result = _service.GetAllOrders();
            return Ok(result);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpPost]
    [Route("")]
    public ActionResult<Order> CreateNewOrder(OrderDTO dto)
    {
        try
        {
            var result = _service.CreateNewOrder(dto);
            return Created("Order/" + result.Id, result);
        }
        catch (ValidationException e)
        {
            return BadRequest(e.Message);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpPut]
    [Route("{id}")]
    public ActionResult<Order> UpdateOrder([FromRoute]int id, [FromBody]Order order)
    {
        try
        {
            return Ok(_service.UpdateOrder(id, order));
        }
        catch (ValidationException validationException)
        {
            return BadRequest(validationException.Message);
        }
        catch (KeyNotFoundException e) 
        {
            return NotFound("Order with ID:" + id + " not found.");
        } catch (Exception e)
        {
            return StatusCode(500, e.ToString());
        }
    }

    [HttpDelete]
    [Route("{id}")]
    public ActionResult<Order> DeleteOrder(int id)
    {
        try
        {
            return Ok(_service.DeleteOrder(id));
        } catch (KeyNotFoundException e) 
        {
            return NotFound("Order with ID:" + id + " not found.");
        } catch (Exception e)
        {
            return StatusCode(500, e.ToString());
        }
    }
    [HttpGet]
    [Route("{id}")]
    public ActionResult<Order> GetOrderById([FromRoute]int id)
    {
        try
        {
            return Ok(_service.GetOrderById(id));
        }
        catch (KeyNotFoundException e) 
        {
            return NotFound("Order with ID:" + id + " not found.");
        } catch (Exception e)
        {
            return StatusCode(500, e.ToString());
        }
    }
}