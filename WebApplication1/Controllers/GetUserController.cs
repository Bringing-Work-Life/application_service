using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using MyMicroservice.Models;
using WebApplication1.Interfaces;
using WebApplication1.Repositories;
using WebApplication1.Service;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetUserController : ControllerBase
    {
        private readonly ILoginRepository _LoginRepository;
        private readonly IMapper _mapper;
        private readonly LoginService _loginService;

        public GetUserController(ILoginRepository loginRepository, IMapper mapper, LoginService loginService)
        {
            _LoginRepository = loginRepository;
            _mapper = mapper;
            _loginService = loginService;
        }

        // Post User data
        [HttpPost("/Login")]

        public async Task<IActionResult> GetUser([FromBody] LoginRequestDto loginRequestDto)
        {
          
            var loginRequest = _mapper.Map<LoginRequest>(loginRequestDto);
            var newId = await _loginService.LoginAsync(loginRequest);
            if (string.IsNullOrEmpty(newId.Token))
                return Unauthorized(newId.Message);

            return Ok(newId);
            //var successResponse = new ApiResponse<LoginRequestDto>
            //{
            //    Success = true,
            //    Message = "User Logged in successfully.",
            //    Data = newId
            //};

            //return CreatedAtAction(nameof(GetUser), new { id = newId }, successResponse); // 200 GetDetails
            
        }
    }
}
