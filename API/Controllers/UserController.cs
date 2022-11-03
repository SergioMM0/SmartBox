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
public class UserController : ControllerBase
{
    private IUserService _service;

    public UserController(IUserService service)
    {
        _service = service;
    }

    [HttpGet]
    public ActionResult<ICollection<User>> GetAllUsers()
    {
        try
        {
            var result = _service.GetAllUsers();
            return Ok(result);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpPost]
    [Route("")]
    public ActionResult<User> CreateNewUser(PostUserDTO dto)
    {
        try
        {
            var result = _service.CreateNewUser(dto);
            return Created("User/" + result.Id, result);
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
    [Route("{id}")]//http://www.misco.es/user/2
    public ActionResult<User> UpdateUser([FromRoute]int id, [FromBody]PutUserDTO putUserDto)
    {
        try
        {
            return Ok(_service.UpdateUser(id, putUserDto));
        }
        catch (ValidationException validationException)
        {
            return BadRequest(validationException.Message);
        }
        catch (KeyNotFoundException e) 
        {
            return NotFound("User with ID:" + id + " not found.");
        } catch (Exception e)
        {
            return StatusCode(500, e.ToString());
        }
    }

    [HttpGet]
    [Route("{id}")]
    public ActionResult<User> GetUserById([FromRoute]int id)
    {
        try
        {
            return Ok(_service.GetUserById(id));
        }
        catch (KeyNotFoundException e) 
        {
            return NotFound("User with ID:" + id + " not found.");
        } catch (Exception e)
        {
            return StatusCode(500, e.ToString());
        }
    }
    
    [HttpDelete]
    [Route("{id}")]
    public ActionResult<User> DeleteUser(int id)
    {
        try
        {
            return Accepted(_service.DeleteUser(id));
        } catch (KeyNotFoundException e) 
        {
            return NotFound("User with ID:" + id + " not found.");
        } catch (Exception e)
        {
            return StatusCode(500, e.ToString());
        }
    }
}