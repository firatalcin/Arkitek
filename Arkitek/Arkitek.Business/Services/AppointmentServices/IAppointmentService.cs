using Arkitek.Business.Base;
using Arkitek.Business.DTOs.AppointmentDtos;

namespace Arkitek.Business.Services.AppointmentServices
{
    public interface IAppointmentService
    {
        Task<BaseResult<List<ResultAppointmentDto>>> GetAllAsync();
        Task<BaseResult<ResultAppointmentDto>> GetByIdAsync(int id);
        Task<BaseResult<object>> CreateAsync(CreateAppointmentDto appointmentDto);
        Task<BaseResult<object>> UpdateAsync(UpdateAppointmentDto appointmentDto);
        Task<BaseResult<object>> DeleteAsync(int id);
        Task<BaseResult<object>> ApproveAppointmentAsync(UpdateAppointmentDto appointmentDto);
        Task<BaseResult<object>> CancelAppointmentAsync(UpdateAppointmentDto appointmentDto);
    }
}
