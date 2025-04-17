using MyMicroservice.Models;
using System.Security.Cryptography;
using System.Text;
using WebApplication1.Repositories;

namespace WebApplication1.Service;
public class LoginService
{
    private readonly LoginRepository _loginRepository;
    private readonly ITokenService _tokenService;

    public LoginService(LoginRepository loginRepository, ITokenService tokenService)
    {
        _loginRepository = loginRepository;
        _tokenService = tokenService;
    }

    public async Task<LoginResponseDto> LoginAsync(LoginRequest loginRequest)
    {
        var user = await _loginRepository.GetUserAsync(loginRequest);

        if (user == null)
            return new LoginResponseDto { Message = "Invalid username or password" };

        bool isValidPassword = VerifyPassword(loginRequest.Password);

        if (!isValidPassword)
            return new LoginResponseDto { Message = "Invalid username or password" };

        var token = _tokenService.GenerateToken(user);

        return new LoginResponseDto { Token = token, Message = "Login successful" };
    }

    private bool VerifyPassword(string password)
    {
        // Implement password verification logic, e.g., using a hashing algorithm like SHA-256
        string hashedPassword = HashPassword(password);
        return hashedPassword != null;
    }

    private string HashPassword(string password)
    {
        // Implement your hashing logic here
        using (var sha256 = SHA256.Create())
        {
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }
    }
}
