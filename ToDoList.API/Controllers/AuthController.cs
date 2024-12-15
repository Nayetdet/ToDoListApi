using Microsoft.AspNetCore.Mvc;
using ToDoList.API.ViewModels.Auth;
using ToDoList.Application.DTOs.Auth;
using ToDoList.Application.Interfaces;

namespace ToDoList.API.Controllers;

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
    public async Task<ActionResult<TokenDto>> LoginAsync([FromBody] LoginViewModel loginViewModel)
    {
        var token = await _authService.LoginAsync(loginViewModel.ToDto());
        if (token is null)
        {
            return Unauthorized("Invalid credentials");
        }

        return token;
    }

    [HttpPost("register")]
    public async Task<ActionResult<TokenDto>> RegisterAsync([FromBody] RegisterViewModel registerViewModel)
    {
        var token = await _authService.RegisterAsync(registerViewModel.ToDto());
        if (token is null)
        {
            return Unauthorized("Invalid credentials");
        }

        return token;
    }
}