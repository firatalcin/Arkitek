using Arkitek.Business.Base;
using Arkitek.Business.DTOs.AboutDtos;

namespace Arkitek.Business.Services.AboutServices
{
    public interface IAboutService
    {
        Task<BaseResult<List<ResultAboutDto>>> GetAllAsync();
        Task<BaseResult<ResultAboutDto>> GetByIdAsync(int id);
        Task<BaseResult<object>> CreateAsync(CreateAboutDto aboutDto);
        Task<BaseResult<object>> DeleteAsync(int id);
        Task<BaseResult<object>> UpdateAsync(UpdateAboutDto aboutDto);
    }
}
