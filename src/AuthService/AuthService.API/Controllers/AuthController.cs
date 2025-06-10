using Microsoft.AspNetCore.Mvc;
using AuthService.Application.DTOs;
using AuthService.Application.UseCases;

namespace AuthService.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(RegisterUseCase registerUseCase, LoginUseCase loginUseCase) : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto dto)
    {
        var response = await registerUseCase.RegisterAsync(dto);
        return Ok(response);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto dto)
    {
        var response = await loginUseCase.LoginAsync(dto);
        return Ok(response);
    }
}