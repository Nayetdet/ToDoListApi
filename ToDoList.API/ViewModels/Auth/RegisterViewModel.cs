using System.ComponentModel.DataAnnotations;
using ToDoList.Application.DTOs.Auth;

namespace ToDoList.API.ViewModels.Auth;

public class RegisterViewModel
{
    [Required(ErrorMessage = "Name is required")]
    [MinLength(2, ErrorMessage = "Name must be at least 2 characters long")]
    [MaxLength(150, ErrorMessage = "Name must not exceed 150 characters")]
    public required string Name { get; set; }
    
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email address")]
    [MaxLength(100, ErrorMessage = "Email must not exceed 100 characters")]
    public required string Email { get; set; }
    
    [Required(ErrorMessage = "Password is required")]
    [MinLength(8, ErrorMessage = "Password must be at least 8 characters long")]
    [MaxLength(255, ErrorMessage = "Password must not exceed 255 characters")]
    public required string Password { get; set; }

    public RegisterDto ToDto()
    {
        return new RegisterDto
        {
            Name = Name,
            Email = Email,
            Password = Password
        };
    }
}