
using MyMicroservice.Models;

namespace WebApplication1.Interfaces
{
    public interface ISampleRepository
    {
        Task<int> CreateSampleAsync(Sample sample);
        Task<Sample> GetSampleAsync(int id);
        Task<bool> UpdateSampleAsync(Sample sample);
        Task<bool> DeleteSampleAsync(int id);
    }
}
