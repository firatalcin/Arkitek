using Arkitek.Business.Base;
using Arkitek.Business.DTOs.ContactDtos;
using Arkitek.DataAccess.Repositories;
using Arkitek.DataAccess.UOW;
using Arkitek.Entity.Entities;
using FluentValidation;
using Mapster;

namespace Arkitek.Business.Services.ContactServices
{
    public class ContactService(IGenericRepository<Contact> _repository, IUnitOfWork _unitOfWork, IValidator<Contact> _validator) : IContactService
    {
        public async Task<BaseResult<object>> CreateAsync(CreateContactDto ContactDto)
        {
            var value = ContactDto.Adapt<Contact>();

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
                return BaseResult<object>.Fail("Contact Not Found");
            }

            _repository.Delete(value);
            var result = await _unitOfWork.SaveChangesAsync();
            return result ? BaseResult<object>.Success() : BaseResult<object>.Fail("Delete Failed");
        }

        public async Task<BaseResult<List<ResultContactDto>>> GetAllAsync()
        {
            var values = await _repository.GetAllAsync();
            var mappedValues = values.Adapt<List<ResultContactDto>>();
            return BaseResult<List<ResultContactDto>>.Success(mappedValues);
        }

        public async Task<BaseResult<ResultContactDto>> GetByIdAsync(int id)
        {
            var value = await _repository.GetByIdAsync(id);
            if (value is null)
            {
                return BaseResult<ResultContactDto>.Fail("Contact Not Found");
            }
            var mappedResult = value.Adapt<ResultContactDto>();
            return BaseResult<ResultContactDto>.Success(mappedResult);
        }

        public async Task<BaseResult<object>> UpdateAsync(UpdateContactDto ContactDto)
        {
            var value = ContactDto.Adapt<Contact>();
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
