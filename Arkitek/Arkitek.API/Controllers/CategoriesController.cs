using Arkitek.Business.DTOs.CategoryDtos;
using Arkitek.Business.Services.CategoryServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Arkitek.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController(ICategoryService CategoryService) : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<List<ResultCategoryDto>>> GetAll()
        {
            var response = await CategoryService.GetAllAsync();

            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }

        [AllowAnonymous]
        [HttpGet("WithProjects")]
        public async Task<ActionResult<List<ResultCategoryDto>>> GetCategoriesWithProjects()
        {
            var response = await CategoryService.GetCategoriesWithProjectsAsync();

            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResultCategoryDto>> GetById(int id)
        {
            var response = await CategoryService.GetByIdAsync(id);
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryDto categoryDto)
        {
            var response = await CategoryService.CreateAsync(categoryDto);
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCategoryDto categoryDto)
        {
            var response = await CategoryService.UpdateAsync(categoryDto);
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await CategoryService.DeleteAsync(id);
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }

    }
}
