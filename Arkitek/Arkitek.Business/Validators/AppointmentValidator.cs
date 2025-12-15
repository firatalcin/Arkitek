using Arkitek.Entity.Entities;
using FluentValidation;

namespace Arkitek.Business.Validators
{
    public class AppointmentValidator : AbstractValidator<Appointment>
    {
        public AppointmentValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email boş bırakılamaz")
                .EmailAddress().WithMessage("Geçerli bir email girin.");

            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Telefon Numarası Boş Bırakılamaz");

            RuleFor(x => x.NameSurname).NotEmpty().WithMessage("Ad Soyad boş bırakılamaz")
                .MinimumLength(3).WithMessage("Ad Soyad en az 3 karakter olmalıdır.");

            RuleFor(x => x.Message).NotEmpty().WithMessage("Mesaj boş bırakılamaz")
                .MaximumLength(500).WithMessage("Mesaj en fazla 500 karakterden oluşmalıdır");

            RuleFor(x => x.ServiceName).NotEmpty().WithMessage("Servis türü boş bırakılamaz");
            RuleFor(x => x.AppointmentDate).NotEmpty().WithMessage("Tarih boş bırakılamaz");

        }
    }
}
