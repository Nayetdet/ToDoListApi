using ToDoList.Application.DTOs.Auth;

namespace ToDoList.Application.Interfaces;

public interface IAuthService
{
    Task<TokenDto?> LoginAsync(LoginDto loginDto);
    Task<TokenDto?> RegisterAsync(RegisterDto registerDto);
}