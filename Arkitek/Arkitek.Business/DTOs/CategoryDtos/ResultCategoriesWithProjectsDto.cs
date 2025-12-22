using Arkitek.Business.DTOs.ProjectDtos;

namespace Arkitek.Business.DTOs.CategoryDtos
{
    public record ResultCategoriesWithProjectsDto(
    int Id,
    string CategoryName,
    IList<ProjectDto> Projects
);
}
