using Arkitek.Entity.Entities;
using FluentValidation;

namespace Arkitek.Business.Validators
{
    public class BannerValidator : AbstractValidator<Banner>
    {
        public BannerValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık boş bırakılamaz.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama boş bırakılamaz.");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Resim  boş bırakılamaz.");
        }
    }
}
