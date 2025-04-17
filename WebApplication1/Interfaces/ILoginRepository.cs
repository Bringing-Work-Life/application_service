
using MyMicroservice.Models;

namespace WebApplication1.Interfaces
{
    public interface ILoginRepository
    {
        Task<LoginResponseDto> GetUserAsync(LoginRequest loginRequest);
    }
}
