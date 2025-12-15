using Arkitek.Entity.Enums;

namespace Arkitek.Business.DTOs.AppointmentDtos
{
    public record CreateAppointmentDto(
     string NameSurname,
     string Email,
     string PhoneNumber,
     string ServiceName,
     DateTime AppointmentDate,
     string Message,
     AppointmentStatus Status = 0);
}
