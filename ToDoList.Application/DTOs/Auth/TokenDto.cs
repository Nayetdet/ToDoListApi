using ToDoList.Application.DTOs.User;

namespace ToDoList.Application.DTOs.Auth;

public class TokenDto
{
    public string AccessToken { get; set; } = null!;
    public DateTime ExpiresAt { get; set; }
    public UserDto User { get; set; } = null!;
}