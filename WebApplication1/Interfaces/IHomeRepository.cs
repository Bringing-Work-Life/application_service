
using MyMicroservice.Models;

namespace WebApplication1.Interfaces
{
    public interface IHomeRepository
    {
        Task<Home[]> GetHomeAsync();
    }
}
