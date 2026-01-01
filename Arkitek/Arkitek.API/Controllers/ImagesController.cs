using Arkitek.Business.Services.FileServices;
using Microsoft.AspNetCore.Mvc;

namespace Arkitek.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController(IFileService fileService) : ControllerBase
    {

        [HttpPost("upload")]
        public async Task<IActionResult> FileUpload(IFormFile file)
        {
            var response = await fileService.UploadImageToS3Async(file);
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteFile([FromQuery] string imageUrl)
        {
            var response = await fileService.DeleteFileAsync(imageUrl);
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }
    }
}
