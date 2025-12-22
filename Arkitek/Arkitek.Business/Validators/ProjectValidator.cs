using Arkitek.Entity.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arkitek.Business.Validators
{
    public class ProjectValidator : AbstractValidator<Project>
    {
        public ProjectValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık boş bırakılamaz");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama boş bırakılamaz");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Resim boş bırakılamaz");
            RuleFor(x => x.Item1).NotEmpty().WithMessage("Madde 1 boş bırakılamaz");
            RuleFor(x => x.Item2).NotEmpty().WithMessage("Madde 2 boş bırakılamaz");
            RuleFor(x => x.Item3).NotEmpty().WithMessage("Madde 3 boş bırakılamaz");
            RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Kategori boş bırakılamaz");
        }
    }
}
