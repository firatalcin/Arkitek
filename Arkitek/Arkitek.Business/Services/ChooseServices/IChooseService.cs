using Arkitek.Business.Base;
using Arkitek.Business.DTOs.ChooseDtos;

namespace Arkitek.Business.Services.ChooseServices
{
    public interface IChooseService
    {
        Task<BaseResult<List<ResultChooseDto>>> GetAllAsync();
        Task<BaseResult<ResultChooseDto>> GetByIdAsync(int id);
        Task<BaseResult<object>> CreateAsync(CreateChooseDto chooseDto);
        Task<BaseResult<object>> DeleteAsync(int id);
        Task<BaseResult<object>> UpdateAsync(UpdateChooseDto chooseDto);
    }
}
