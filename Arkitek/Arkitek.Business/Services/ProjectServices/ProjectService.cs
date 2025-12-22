using Arkitek.Business.Base;
using Arkitek.Business.DTOs.ProjectDtos;
using Arkitek.DataAccess.Repositories;
using Arkitek.DataAccess.UOW;
using Arkitek.Entity.Entities;
using FluentValidation;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arkitek.Business.Services.ProjectServices
{
    public class ProjectService(IGenericRepository<Project> _repository, IUnitOfWork _unitOfWork, IValidator<Project> _validator) : IProjectService
    {
        public async Task<BaseResult<object>> CreateAsync(CreateProjectDto projectDto)
        {
            var value = projectDto.Adapt<Project>();
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
                return BaseResult<object>.Fail("Project Not Found");
            }

            _repository.Delete(value);
            var result = await _unitOfWork.SaveChangesAsync();
            return result ? BaseResult<object>.Success() : BaseResult<object>.Fail("Delete Failed");
        }

        public async Task<BaseResult<List<ResultProjectDto>>> GetAllAsync()
        {
            var values = await _repository.GetAllAsync();
            var mappedValues = values.Adapt<List<ResultProjectDto>>();
            return BaseResult<List<ResultProjectDto>>.Success(mappedValues);
        }

        public async Task<BaseResult<ResultProjectDto>> GetByIdAsync(int id)
        {
            var value = await _repository.GetByIdAsync(id);
            if (value is null)
            {
                return BaseResult<ResultProjectDto>.Fail("Project Not Found");
            }
            var mappedResult = value.Adapt<ResultProjectDto>();
            return BaseResult<ResultProjectDto>.Success(mappedResult);
        }

        public async Task<BaseResult<List<ResultProjectDto>>> GetProjectsWithCategories()
        {
            var queryable = _repository.GetQueryable();

            var products = await queryable.Include(x => x.Category).ToListAsync();
            var mappedValues = products.Adapt<List<ResultProjectDto>>();
            return BaseResult<List<ResultProjectDto>>.Success(mappedValues);
        }

        public async Task<BaseResult<object>> UpdateAsync(UpdateProjectDto projectDto)
        {
            var value = projectDto.Adapt<Project>();
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
