namespace Arkitek.Business.DTOs.BannerDtos
{
    public record CreateBannerDto(
                           string? Title,
                           string? Description,
                           string? ImageUrl);
}
