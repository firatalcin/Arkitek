using Arkitek.Entity.Entities;
using FluentValidation;

namespace Arkitek.Business.Validators
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage("Kategori adı boş bırakılamaz");

        }
    }
}
