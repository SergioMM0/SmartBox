using Domain;
using Domain.Interfaces;
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
}