using Microsoft.AspNetCore.Mvc;
using MyApp.Models;
using MyApp.Services;

namespace MyApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public IActionResult Login(string username, string password)
    {
        var ok = _authService.AuthenticateUser(username, password);
        if (!ok)
            return Unauthorized();
        var session = _authService.CreateSession(0);
        return Ok(session);
    }

    [HttpGet("health")]
    public IActionResult HealthCheck()
    {
        return Ok("healthy");
    }
}
