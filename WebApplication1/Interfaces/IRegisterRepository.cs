
using MyMicroservice.Models;

namespace WebApplication1.Interfaces
{
    public interface IRegisterRepository
    {
        Task<Register> PostRegisterAsync(Register register);
    }
}
