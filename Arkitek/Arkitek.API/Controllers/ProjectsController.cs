using Arkitek.Business.DTOs.ProjectDtos;
using Arkitek.Business.Services.ProjectServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Arkitek.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController(IProjectService projectService) : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<List<ResultProjectDto>>> GetAll()
        {
            var response = await projectService.GetAllAsync();

            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }

        [AllowAnonymous]
        [HttpGet("WithCategories")]
        public async Task<ActionResult<List<ResultProjectDto>>> GetProjectsWithCategories()
        {
            var response = await projectService.GetProjectsWithCategories();

            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<ResultProjectDto>> GetById(int id)
        {
            var response = await projectService.GetByIdAsync(id);
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProjectDto projectDto)
        {
            var response = await projectService.CreateAsync(projectDto);
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateProjectDto projectDto)
        {
            var response = await projectService.UpdateAsync(projectDto);
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await projectService.DeleteAsync(id);
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }
    }
}
