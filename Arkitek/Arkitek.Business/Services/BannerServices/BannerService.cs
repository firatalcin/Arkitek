using Arkitek.Business.Base;
using Arkitek.Business.DTOs.BannerDtos;
using Arkitek.DataAccess.Repositories;
using Arkitek.DataAccess.UOW;
using Arkitek.Entity.Entities;
using FluentValidation;
using Mapster;

namespace Arkitek.Business.Services.BannerServices
{
    public class BannerService(IGenericRepository<Banner> _repository, IUnitOfWork _unitOfWork, IValidator<Banner> _validator) : IBannerService
    {
        public async Task<BaseResult<object>> CreateAsync(CreateBannerDto bannerDto)
        {

            var banner = bannerDto.Adapt<Banner>();
            var validationResult = await _validator.ValidateAsync(banner);
            if (!validationResult.IsValid)
            {
                return BaseResult<object>.Fail(validationResult.Errors);
            }

            await _repository.CreateAsync(banner);
            var result = await _unitOfWork.SaveChangesAsync();
            return result ? BaseResult<object>.Success(banner) : BaseResult<object>.Fail("Create Failed");
        }

        public async Task<BaseResult<object>> DeleteAsync(int id)
        {
            var banner = await _repository.GetByIdAsync(id);
            if (banner is null)
            {
                return BaseResult<object>.Fail("Banner Not Found");
            }

            _repository.Delete(banner);
            var result = await _unitOfWork.SaveChangesAsync();
            return result ? BaseResult<object>.Success() : BaseResult<object>.Fail("Delete Failed");
        }

        public async Task<BaseResult<List<ResultBannerDto>>> GetAllAsync()
        {
            var banners = await _repository.GetAllAsync();
            var mappedResult = banners.Adapt<List<ResultBannerDto>>();
            return BaseResult<List<ResultBannerDto>>.Success(mappedResult);
        }

        public async Task<BaseResult<ResultBannerDto>> GetByIdAsync(int id)
        {
            var banner = await _repository.GetByIdAsync(id);
            if (banner is null)
            {
                return BaseResult<ResultBannerDto>.Fail("Banner Not Found");
            }

            var mappedResult = banner.Adapt<ResultBannerDto>();
            return BaseResult<ResultBannerDto>.Success(mappedResult);
        }

        public async Task<BaseResult<object>> UpdateAsync(UpdateBannerDto bannerDto)
        {
            var banner = bannerDto.Adapt<Banner>();
            var validationResult = await _validator.ValidateAsync(banner);
            if (!validationResult.IsValid)
            {
                return BaseResult<object>.Fail(validationResult.Errors);
            }

            _repository.Update(banner);
            var result = await _unitOfWork.SaveChangesAsync();
            return result ? BaseResult<object>.Success() : BaseResult<object>.Fail("Update Failed");

        }
    }
}
