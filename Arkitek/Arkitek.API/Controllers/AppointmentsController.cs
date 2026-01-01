using Arkitek.Business.DTOs.AppointmentDtos;
using Arkitek.Business.Services.AppointmentServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Arkitek.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController(IAppointmentService appointmentService) : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Create(CreateAppointmentDto appointmentDto)
        {
            var response = await appointmentService.CreateAsync(appointmentDto);
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }

        [HttpGet]
        public async Task<ActionResult<List<ResultAppointmentDto>>> GetAll()
        {
            var response = await appointmentService.GetAllAsync();
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResultAppointmentDto>> GetById(int id)
        {
            var response = await appointmentService.GetByIdAsync(id);
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateAppointmentDto appointmentDto)
        {
            var response = await appointmentService.UpdateAsync(appointmentDto);
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await appointmentService.DeleteAsync(id);
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }

        [HttpPatch("Approve")]
        public async Task<IActionResult> Approve(UpdateAppointmentDto appointmentDto)
        {
            var response = await appointmentService.ApproveAppointmentAsync(appointmentDto);
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }

        [HttpPatch("Cancel")]
        public async Task<IActionResult> Cancel(UpdateAppointmentDto appointmentDto)
        {
            var response = await appointmentService.CancelAppointmentAsync(appointmentDto);
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }
    }
}
