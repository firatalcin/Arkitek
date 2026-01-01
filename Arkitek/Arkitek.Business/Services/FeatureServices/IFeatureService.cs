using Arkitek.Business.Base;
using Arkitek.Business.DTOs.FeatureDtos;

namespace Arkitek.Business.Services.FeatureServices
{
    public interface IFeatureService
    {
        Task<BaseResult<List<ResultFeatureDto>>> GetAllAsync();
        Task<BaseResult<ResultFeatureDto>> GetByIdAsync(int id);
        Task<BaseResult<object>> CreateAsync(CreateFeatureDto featureDto);
        Task<BaseResult<object>> DeleteAsync(int id);
        Task<BaseResult<object>> UpdateAsync(UpdateFeatureDto featureDto);
    }
}
