using Microsoft.AspNetCore.Mvc;
using MyMicroservice.Models;
using WebApplication1.Interfaces;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IHomeRepository _homeRepository;

        public HomeController(IHomeRepository homeRepository)
        {
            _homeRepository = homeRepository;
        }

        // GET Master Home data
        [HttpGet("/home")]
        public async Task<IActionResult> GetHome()
        {
            var home = await _homeRepository.GetHomeAsync();
            if (home == null)
            {
                return NotFound();
            }
            return Ok(home);
        }
    }
}
