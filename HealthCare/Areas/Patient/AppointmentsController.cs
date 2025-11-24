using HealthCare.BLL.Services.Interfaces;
using HealthCare.DAL.DTO.Requests;
using HealthCare.DAL.DTO.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare.PL.Areas.Patient
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Area("Patient")]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentsController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }
        [HttpPost("")]
        public async Task<ActionResult<AppointmentResponseDto>> AddAppointmentAsync([FromBody]AppointmentRequestDto appointmentRequest)
        {
            var result = await _appointmentService.AddAsync(appointmentRequest);
            return Ok(result);
        }
    }
}
