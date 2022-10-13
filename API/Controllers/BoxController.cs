using Application.Validators;
using Domain;
using Domain.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class BoxController : ControllerBase
{
    private IBoxService _boxService;

    public BoxController(IBoxService service)
    {
        _boxService = service;
    }

    [HttpGet]
    public List<Box> GetAllProducts()
    {
        return _boxService.GetAllBoxes();
    }

    [HttpPost]
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