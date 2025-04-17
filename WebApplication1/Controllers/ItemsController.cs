using Microsoft.AspNetCore.Mvc;
using MyMicroservice.Models;
using WebApplication1.Interfaces;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SampleController : ControllerBase
    {
        private readonly ISampleRepository _sampleRepository;

        public SampleController(ISampleRepository sampleRepository)
        {
            _sampleRepository = sampleRepository;
        }

        // POST api/sample
        [HttpPost]
        public async Task<IActionResult> CreateSample([FromBody] SampleDto sampleDto)
        {
            if (sampleDto == null)
            {
                return BadRequest();
            }

            var sample = new Sample
            {
                Name = sampleDto.Name,
                Description = sampleDto.Description
            };

            var newSampleId = await _sampleRepository.CreateSampleAsync(sample);
            return CreatedAtAction(nameof(GetSample), new { id = newSampleId }, newSampleId);
        }

        // GET api/sample/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSample(int id)
        {
            var sample = await _sampleRepository.GetSampleAsync(id);

            if (sample == null)
            {
                return NotFound();
            }

            var sampleDto = new SampleDto
            {
                Id = sample.Id,
                Name = sample.Name,
                Description = sample.Description
            };

            return Ok(sampleDto);
        }

        // PUT api/sample/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSample(int id, [FromBody] SampleDto sampleDto)
        {
            if (sampleDto == null || id != sampleDto.Id)
            {
                return BadRequest();
            }

            var sample = new Sample
            {
                Id = sampleDto.Id,
                Name = sampleDto.Name,
                Description = sampleDto.Description
            };

            var result = await _sampleRepository.UpdateSampleAsync(sample);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE api/sample/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSample(int id)
        {
            var result = await _sampleRepository.DeleteSampleAsync(id);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
