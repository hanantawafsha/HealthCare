using HealthCare.BLL.Services.Interfaces;
using HealthCare.DAL.DTO.Requests;
using HealthCare.DAL.DTO.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System.Security.Claims;

namespace HealthCare.PL.Areas.Patient
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Area("Patient")]
    [Authorize(Roles ="Patient")]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IStringLocalizer<SharedResource> _localizer;

        public AppointmentsController(IAppointmentService appointmentService,
            IStringLocalizer<SharedResource> localizer)
        {
            _appointmentService = appointmentService;
            _localizer = localizer;
        }
        [HttpPost("Add/{doctorId}")]
        public async Task<ActionResult<AppointmentResponseDto>> AddAppointmentAsync([FromRoute] string doctorId,[FromBody] AppointmentRequestDto appointmentRequest)
        {
            var patientId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = await _appointmentService.CreateAppointmentAsync(patientId, doctorId,appointmentRequest);
            return Ok(result);
        }
        [HttpPatch("update/{id}")]
        public async Task<ActionResult> UpdateAppointment([FromRoute] int id, AppointmentRequestDto request )
        {
            //var patientId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = await _appointmentService.UpdateAppointmentAsyn(id, request);
            return Ok(new { Message = _localizer["SuccessUpdate"].Value });
        }
        //update status 
    }
}
