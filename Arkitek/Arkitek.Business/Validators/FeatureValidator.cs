using Arkitek.Entity.Entities;
using FluentValidation;

namespace Arkitek.Business.Validators
{
    public class FeatureValidator : AbstractValidator<Feature>
    {
        public FeatureValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık boş bırakılamaz.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama boş bırakılamaz.");
            RuleFor(x => x.BackgroundImage).NotEmpty().WithMessage("Arkaplan resmi boş bırakılamaz.");
            RuleFor(x => x.Icon).NotEmpty().WithMessage("İkon boş bırakılamaz.");
        }
    }
}
