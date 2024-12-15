using System.ComponentModel.DataAnnotations;
using ToDoList.Application.DTOs.Auth;

namespace ToDoList.API.ViewModels.Auth;

public class LoginViewModel
{
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email address")]
    [MaxLength(100, ErrorMessage = "Email must not exceed 100 characters")]
    public required string Email { get; set; }

    [Required(ErrorMessage = "Password is required")]
    [MinLength(8, ErrorMessage = "Password must be at least 8 characters long")]
    [MaxLength(255, ErrorMessage = "Password must not exceed 255 characters")]
    public required string Password { get; set; }

    public LoginDto ToDto()
    {
        return new LoginDto
        {
            Email = Email,
            Password = Password
        };
    }
}