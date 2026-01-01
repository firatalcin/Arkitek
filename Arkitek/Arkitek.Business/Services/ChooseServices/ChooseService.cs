using Arkitek.Business.Base;
using Arkitek.Business.DTOs.ChooseDtos;
using Arkitek.DataAccess.Repositories;
using Arkitek.DataAccess.UOW;
using Arkitek.Entity.Entities;
using FluentValidation;
using Mapster;

namespace Arkitek.Business.Services.ChooseServices
{
    public class ChooseService(IGenericRepository<Choose> _repository, IUnitOfWork _unitOfWork, IValidator<Choose> _validator) : IChooseService
    {
        public async Task<BaseResult<object>> CreateAsync(CreateChooseDto chooseDto)
        {
            var value = chooseDto.Adapt<Choose>();

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
                return BaseResult<object>.Fail("Choose Not Found");
            }

            _repository.Delete(value);
            var result = await _unitOfWork.SaveChangesAsync();
            return result ? BaseResult<object>.Success() : BaseResult<object>.Fail("Delete Failed");
        }

        public async Task<BaseResult<List<ResultChooseDto>>> GetAllAsync()
        {
            var values = await _repository.GetAllAsync();
            var mappedValues = values.Adapt<List<ResultChooseDto>>();
            return BaseResult<List<ResultChooseDto>>.Success(mappedValues);
        }

        public async Task<BaseResult<ResultChooseDto>> GetByIdAsync(int id)
        {
            var value = await _repository.GetByIdAsync(id);
            if (value is null)
            {
                return BaseResult<ResultChooseDto>.Fail("Choose Not Found");
            }
            var mappedResult = value.Adapt<ResultChooseDto>();
            return BaseResult<ResultChooseDto>.Success(mappedResult);
        }

        public async Task<BaseResult<object>> UpdateAsync(UpdateChooseDto chooseDto)
        {
            var value = chooseDto.Adapt<Choose>();
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
