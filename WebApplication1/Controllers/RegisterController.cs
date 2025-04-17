using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using MyMicroservice.Models;
using WebApplication1.Interfaces;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IRegisterRepository _RegisterRepository;
        private readonly IMapper _mapper;

        public RegisterController(IRegisterRepository registerRepository, IMapper mapper)
        {
            _RegisterRepository = registerRepository;
            _mapper = mapper;
        }

        // Post User data
        [HttpPost("/Register")]

        public async Task<IActionResult> PostRegister([FromBody] RegisterDto registerDto)
        {
          
            var register = _mapper.Map<Register>(registerDto);
            var newId = await _RegisterRepository.PostRegisterAsync(register);
            var successResponse = new ApiResponse<RegisterDto>
            {
                Success = true,
                Message = "User registered successfully.",
                Data = registerDto
            };

            return CreatedAtAction(nameof(PostRegister), new { id = newId }, successResponse); // 201 Created
            
        }
    }
}
