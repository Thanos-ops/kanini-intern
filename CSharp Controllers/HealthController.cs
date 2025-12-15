using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/")]
public class HealthController : ControllerBase
{
    [HttpGet]
    public IActionResult Get() => Ok(new { status = "ok", service = "Food API" });
}