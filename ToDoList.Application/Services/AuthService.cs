using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ToDoList.Application.DTOs.Auth;
using ToDoList.Application.DTOs.User;
using ToDoList.Application.Interfaces;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Interfaces;

namespace ToDoList.Application.Services;

public class AuthService : IAuthService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPasswordHasher<User> _passwordHasher;
    private readonly IConfiguration _configuration;

    public AuthService(IUnitOfWork unitOfWork, IPasswordHasher<User> passwordHasher, IConfiguration configuration)
    {
        _unitOfWork = unitOfWork;
        _passwordHasher = passwordHasher;
        _configuration = configuration;
    }
    
    public async Task<TokenDto?> LoginAsync(LoginDto loginDto)
    {
        var user = await _unitOfWork.UserRepository.GetByEmailAsync(loginDto.Email);
        if (user is null)
        {
            return null;
        }
        
        var result = _passwordHasher.VerifyHashedPassword(user, user.Password, loginDto.Password);
        if (result == PasswordVerificationResult.Failed)
        {
            return null;
        }
        
        return GenerateAccessToken(user);
    }

    public async Task<TokenDto?> RegisterAsync(RegisterDto registerDto)
    {
        if (!await _unitOfWork.UserRepository.IsEmailAvailableAsync(registerDto.Email))
        {
            return null;
        }

        var user = new User(registerDto.Name, registerDto.Email, registerDto.Password);
        user.ChangePassword(_passwordHasher.HashPassword(user, registerDto.Password));
        _unitOfWork.UserRepository.Create(user);
        await _unitOfWork.CommitAsync();
        return GenerateAccessToken(user);
    }
    
    private TokenDto GenerateAccessToken(User user)
    {
        var key = Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"]!);
        var expiresAt = DateTime.UtcNow.AddMinutes(int.Parse(_configuration["JWT:TokenValidityInMinutes"]!));
        
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new("Id", user.Id.ToString()),
                new(ClaimTypes.Name, user.Name),
                new(ClaimTypes.Email, user.Email),
            }),
            Expires = expiresAt,
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        var encodedToken = tokenHandler.WriteToken(token);

        return new TokenDto
        {
            AccessToken = encodedToken,
            ExpiresAt = expiresAt,
            User = new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
            }
        };
    }
}