using AutoMapper;
using MyMicroservice.Models;
namespace WebApplication1.Bootstrap
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Sample, SampleDto>().ReverseMap();
            CreateMap<Register, RegisterDto>().ReverseMap();
            CreateMap<Home, HomeDto>().ReverseMap();
            CreateMap<LoginRequest, LoginRequestDto>().ReverseMap();
        }
    }
}
