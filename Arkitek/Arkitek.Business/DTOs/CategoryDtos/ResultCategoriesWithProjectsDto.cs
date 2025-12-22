using Arkitek.Business.DTOs.ProjectDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arkitek.Business.DTOs.CategoryDtos
{
    public record ResultCategoriesWithProjectsDto(
    int Id,
    string CategoryName,
    IList<ProjectDto> Projects
);
}
