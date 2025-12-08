using Arkitek.Business.Base;
using Arkitek.Business.DTOs.AboutDtos;
using Arkitek.DataAccess.Repositories;
using Arkitek.DataAccess.UOW;
using Arkitek.Entity.Entities;
using FluentValidation;
using Mapster;

namespace Arkitek.Business.Services.AboutServices
{
    public class AboutService(
        IGenericRepository<About> aboutRepository,
        IUnitOfWork unitOfWork,
        IValidator<About> validator) : IAboutService
    {
        public async Task<BaseResult<object>> CreateAsync(CreateAboutDto aboutDto)
        {
            var about = aboutDto.Adapt<About>();
            await aboutRepository.CreateAsync(about);
            await unitOfWork.SaveChangesAsync();
            return BaseResult<object>.Success(about);
        }

        public async Task<BaseResult<object>> DeleteAsync(int id)
        {
            var about = await aboutRepository.GetByIdAsync(id);
            if (about is null)
            {
                return BaseResult<object>.Fail("About Not Found");
            }

            aboutRepository.Delete(about);
            var result = await unitOfWork.SaveChangesAsync();
            return result ? BaseResult<object>.Success() : BaseResult<object>.Fail("Delete Failed");
        }

        public async Task<BaseResult<List<ResultAboutDto>>> GetAllAsync()
        {
            var abouts = await aboutRepository.GetAllAsync();
            var mappedValue = abouts.Adapt<List<ResultAboutDto>>();
            return BaseResult<List<ResultAboutDto>>.Success(mappedValue);
        }

        public async Task<BaseResult<ResultAboutDto>> GetByIdAsync(int id)
        {
            var about = await aboutRepository.GetByIdAsync(id);
            if (about is null)
            {
                return BaseResult<ResultAboutDto>.Fail("About Not Found");
            }
            var mappedResult = about.Adapt<ResultAboutDto>();
            return BaseResult<ResultAboutDto>.Success(mappedResult);
        }

        public async Task<BaseResult<object>> UpdateAsync(UpdateAboutDto aboutDto)
        {
            var about = aboutDto.Adapt<About>();
            aboutRepository.Update(about);
            var result = await unitOfWork.SaveChangesAsync();
            return result ? BaseResult<object>.Success() : BaseResult<object>.Fail("Update Failed");
        }
    }
}
