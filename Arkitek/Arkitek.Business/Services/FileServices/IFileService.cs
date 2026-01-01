using Arkitek.Business.Base;
using Microsoft.AspNetCore.Http;

namespace Arkitek.Business.Services.FileServices
{
    public interface IFileService
    {
        Task<BaseResult<object>> UploadImageToS3Async(IFormFile? file);

        Task<BaseResult<object>> DeleteFileAsync(string imageUrl);
    }
}
