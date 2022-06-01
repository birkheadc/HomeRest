using Microsoft.AspNetCore.Mvc;

namespace HomeRest.Controllers;

[ApiController]
[Route("api/debug")]
public class DebugController : ControllerBase
{
    [HttpPost]
    [Route("populate")]
    public IActionResult PopulateDatabases()
    {
        try
        {
            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
}