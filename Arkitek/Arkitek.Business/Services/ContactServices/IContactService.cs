using Arkitek.Business.Base;
using Arkitek.Business.DTOs.ContactDtos;

namespace Arkitek.Business.Services.ContactServices
{
    public interface IContactService
    {
        Task<BaseResult<List<ResultContactDto>>> GetAllAsync();
        Task<BaseResult<ResultContactDto>> GetByIdAsync(int id);
        Task<BaseResult<object>> CreateAsync(CreateContactDto contactDto);
        Task<BaseResult<object>> DeleteAsync(int id);
        Task<BaseResult<object>> UpdateAsync(UpdateContactDto contactDto);
    }
}
