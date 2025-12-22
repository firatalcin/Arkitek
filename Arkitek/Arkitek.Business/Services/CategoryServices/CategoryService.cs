using Arkitek.Business.Base;
using Arkitek.Business.DTOs.CategoryDtos;
using Arkitek.DataAccess.Repositories;
using Arkitek.DataAccess.UOW;
using Arkitek.Entity.Entities;
using FluentValidation;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Arkitek.Business.Services.CategoryServices
{
    public class CategoryService(IGenericRepository<Category> _repository, IUnitOfWork _unitOfWork, IValidator<Category> _validator) : ICategoryService
    {
        public async Task<BaseResult<object>> CreateAsync(CreateCategoryDto categoryDto)
        {
            var category = categoryDto.Adapt<Category>();
            var validationResult = await _validator.ValidateAsync(category);
            if (!validationResult.IsValid)
            {
                return BaseResult<object>.Fail(validationResult.Errors);
            }

            await _repository.CreateAsync(category);
            var result = await _unitOfWork.SaveChangesAsync();
            return result ? BaseResult<object>.Success(category) : BaseResult<object>.Fail("Create Failed");
        }

        public async Task<BaseResult<object>> DeleteAsync(int id)
        {
            var category = await _repository.GetByIdAsync(id);
            if (category is null)
            {
                return BaseResult<object>.Fail("Category Not Found");
            }

            _repository.Delete(category);
            var result = await _unitOfWork.SaveChangesAsync();
            return result ? BaseResult<object>.Success() : BaseResult<object>.Fail("Delete Failed");


        }

        public async Task<BaseResult<List<ResultCategoryDto>>> GetAllAsync()
        {
            var categories = await _repository.GetAllAsync();
            var mappedResult = categories.Adapt<List<ResultCategoryDto>>();
            return BaseResult<List<ResultCategoryDto>>.Success(mappedResult);
        }

        public async Task<BaseResult<ResultCategoryDto>> GetByIdAsync(int id)
        {
            var category = await _repository.GetByIdAsync(id);
            if (category is null)
            {
                return BaseResult<ResultCategoryDto>.Fail("Category Not Found");
            }

            var mappedResult = category.Adapt<ResultCategoryDto>();
            return BaseResult<ResultCategoryDto>.Success(mappedResult);
        }

        public async Task<BaseResult<List<ResultCategoriesWithProjectsDto>>> GetCategoriesWithProjectsAsync()
        {
            var categories = await _repository.GetQueryable().Include(x => x.Projects).ToListAsync();
            var mappedResult = categories.Adapt<List<ResultCategoriesWithProjectsDto>>();
            return BaseResult<List<ResultCategoriesWithProjectsDto>>.Success(mappedResult);
        }

        public async Task<BaseResult<object>> UpdateAsync(UpdateCategoryDto categoryDto)
        {
            var category = categoryDto.Adapt<Category>();
            var validationResult = await _validator.ValidateAsync(category);
            if (!validationResult.IsValid)
            {
                return BaseResult<object>.Fail(validationResult.Errors);
            }
            _repository.Update(category);
            var result = await _unitOfWork.SaveChangesAsync();
            return result ? BaseResult<object>.Success() : BaseResult<object>.Fail("Update Failed");
        }
    }
}
