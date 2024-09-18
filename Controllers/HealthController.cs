using Microsoft.AspNetCore.Mvc;

namespace Controllers;

[Route("[controller]")]
[ApiController]
public class HealthController : ControllerBase
{
    [HttpGet]
    public IActionResult GetHealth()
    {
        return Ok("App is running");
    }
}