using Arkitek.Business.Base;
using Arkitek.Business.DTOs.ProjectDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arkitek.Business.Services.ProjectServices
{
    public interface IProjectService
    {
        Task<BaseResult<List<ResultProjectDto>>> GetAllAsync();
        Task<BaseResult<List<ResultProjectDto>>> GetProjectsWithCategories();
        Task<BaseResult<ResultProjectDto>> GetByIdAsync(int id);
        Task<BaseResult<object>> CreateAsync(CreateProjectDto ProjectDto);
        Task<BaseResult<object>> DeleteAsync(int id);
        Task<BaseResult<object>> UpdateAsync(UpdateProjectDto ProjectDto);
    }
}
