using Arkitek.Business.Base;
using Arkitek.Business.DTOs.BannerDtos;

namespace Arkitek.Business.Services.BannerServices
{
    public interface IBannerService
    {
        Task<BaseResult<List<ResultBannerDto>>> GetAllAsync();
        Task<BaseResult<ResultBannerDto>> GetByIdAsync(int id);
        Task<BaseResult<object>> CreateAsync(CreateBannerDto bannerDto);
        Task<BaseResult<object>> DeleteAsync(int id);
        Task<BaseResult<object>> UpdateAsync(UpdateBannerDto bannerDto);
    }
}
