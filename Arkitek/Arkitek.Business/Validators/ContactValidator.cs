using Arkitek.Entity.Entities;
using FluentValidation;

namespace Arkitek.Business.Validators
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.Address).NotEmpty().WithMessage("Adres boş bırakılamaz");
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Telefon boş bırakılamaz");
            RuleFor(x => x.MapUrl).NotEmpty().WithMessage("Harita Url boş bırakılamaz");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email boş bırakılamaz")
                .EmailAddress().WithMessage("Email formatı geçersiz");
        }
    }
}
