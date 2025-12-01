using Arkitek.Entity.Entities.Common;

namespace Arkitek.Entity.Entities
{
    public class Appointment : BaseEntity
    {
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string ServiceName { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Message { get; set; }
        public AppointmentStatus Status { get; set; }
    }
}
