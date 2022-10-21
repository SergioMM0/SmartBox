using Application.DTOs;
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
    [Route("RebuildDb")]
    public void RebuildDb()
    {
        _boxService.RebuildDb();
    }

    [HttpGet]
    public ActionResult<List<Box>> GetAllBoxes()
    {
        try
        {
            var result = _boxService.GetAllBoxes();
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