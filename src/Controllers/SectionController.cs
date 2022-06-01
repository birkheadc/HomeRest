using HomeRest.Models;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Security;

namespace HomeRest.Controllers;

[ApiController]
[Route("api/section")]
public class SectionController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        try
        {
            List<Section> sections = new();
            Section a = new()
            {
                Id = Guid.NewGuid(),
                Title = "First",
                Subtitle = "",
                Body = "This is the first section."
            };
            sections.Add(a);

            Section b = new()
            {
                Id = Guid.NewGuid(),
                Title = "Second",
                Subtitle = "This section has a subtitle!",
                Body = "This is the next section."
            };
            sections.Add(b);

            Section c = new()
            {
                Id = Guid.NewGuid(),
                Title = "Final",
                Subtitle = "",
                Body = "This is the final section."
            };
            sections.Add(c);

            return Ok(sections);
        }
        catch
        {
            return BadRequest("Something went wrong...");
        }
    }
}