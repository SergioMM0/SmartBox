using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class DatabaseController : ControllerBase
{
    private IDatabaseService _DbService;

    public DatabaseController(IDatabaseService service)
    {
        _DbService = service;
    }
    [HttpGet]
    [Route("RebuildDb")]
    public void RebuildDb()
    {
        _DbService.RebuildDb();
    }
    
}