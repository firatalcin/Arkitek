using Arkitek.Business.Base;
using Arkitek.Business.DTOs.FeatureDtos;
using Arkitek.DataAccess.Repositories;
using Arkitek.DataAccess.UOW;
using Arkitek.Entity.Entities;
using FluentValidation;
using Mapster;

namespace Arkitek.Business.Services.FeatureServices
{
    public class FeatureService(IGenericRepository<Feature> _repository, IUnitOfWork _unitOfWork, IValidator<Feature> _validator) : IFeatureService
    {
        public async Task<BaseResult<object>> CreateAsync(CreateFeatureDto FeatureDto)
        {
            var value = FeatureDto.Adapt<Feature>();

            var validationResult = await _validator.ValidateAsync(value);
            if (!validationResult.IsValid)
            {
                return BaseResult<object>.Fail(validationResult.Errors);
            }

            await _repository.CreateAsync(value);
            var result = await _unitOfWork.SaveChangesAsync();
            return result ? BaseResult<object>.Success(value) : BaseResult<object>.Fail("Create Failed");
        }

        public async Task<BaseResult<object>> DeleteAsync(int id)
        {
            var value = await _repository.GetByIdAsync(id);
            if (value is null)
            {
                return BaseResult<object>.Fail("Feature Not Found");
            }

            _repository.Delete(value);
            var result = await _unitOfWork.SaveChangesAsync();
            return result ? BaseResult<object>.Success() : BaseResult<object>.Fail("Delete Failed");
        }

        public async Task<BaseResult<List<ResultFeatureDto>>> GetAllAsync()
        {
            var values = await _repository.GetAllAsync();
            var mappedValues = values.Adapt<List<ResultFeatureDto>>();
            return BaseResult<List<ResultFeatureDto>>.Success(mappedValues);
        }

        public async Task<BaseResult<ResultFeatureDto>> GetByIdAsync(int id)
        {
            var value = await _repository.GetByIdAsync(id);
            if (value is null)
            {
                return BaseResult<ResultFeatureDto>.Fail("Feature Not Found");
            }
            var mappedResult = value.Adapt<ResultFeatureDto>();
            return BaseResult<ResultFeatureDto>.Success(mappedResult);
        }

        public async Task<BaseResult<object>> UpdateAsync(UpdateFeatureDto FeatureDto)
        {
            var value = FeatureDto.Adapt<Feature>();
            var validationResult = await _validator.ValidateAsync(value);
            if (!validationResult.IsValid)
            {
                return BaseResult<object>.Fail(validationResult.Errors);
            }
            _repository.Update(value);
            var result = await _unitOfWork.SaveChangesAsync();
            return result ? BaseResult<object>.Success() : BaseResult<object>.Fail("Update Failed");
        }
    }
}
