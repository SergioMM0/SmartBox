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
public class BoxController : ControllerBase
{
    private IBoxService _boxService;

    public BoxController(IBoxService service)
    {
        _boxService = service;
    }

    [HttpGet]
    public ActionResult<List<Box>> GetAllBoxes()
    {
        try
        {
            var result = _boxService.GetAllBoxes();
            Console.WriteLine("Boxes list count :"+result.Count);
            return Ok(result);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpPost]
    [Route("")]
    public ActionResult<Box> CreateNewBox(PostBoxDTO dto)
    {
        try
        {
            var result = _boxService.CreateNewBox(dto);
            return Created("box/" + result.Id, result);
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
}