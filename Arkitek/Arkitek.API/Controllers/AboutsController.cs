using Arkitek.Business.DTOs.AboutDtos;
using Arkitek.Business.Services.AboutServices;
using Microsoft.AspNetCore.Mvc;

namespace Arkitek.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController(IAboutService aboutService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<ResultAboutDto>> GetAll()
        {
            var response = await aboutService.GetAllAsync();

            return response.IsSuccessful ? Ok(response)
                : BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResultAboutDto>> GetById(int id)
        {
            var response = await aboutService.GetByIdAsync(id);
            return response.IsSuccessful ? Ok(response)
                : BadRequest(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAboutDto createAboutDto)
        {
            var response = await aboutService.CreateAsync(createAboutDto);
            return response.IsSuccessful ? Ok(response)
                : BadRequest(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateAboutDto updateAboutDto)
        {
            var response = await aboutService.UpdateAsync(updateAboutDto);
            return response.IsSuccessful ? Ok()
                : BadRequest(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await aboutService.DeleteAsync(id);
            return response.IsSuccessful ? Ok()
                : BadRequest(response);
        }
    }
}
