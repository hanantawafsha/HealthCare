using HealthCare.BLL.Services.Interfaces;
using HealthCare.DAL.DTO.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System.Security.Claims;

namespace HealthCare.PL.Areas.Doctor
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Area("Doctor")]
    [Authorize(Roles = "Doctor")]

    public class DoctorWorkingHourssController : Controller
    {
        private readonly IDoctorWorkingHoursService _doctorWorkingHoursService;
        private readonly IStringLocalizer<SharedResource> _localizer;

        public DoctorWorkingHourssController(IDoctorWorkingHoursService doctorWorkingHoursService,
            IStringLocalizer<SharedResource> localizer)
        {
            _doctorWorkingHoursService = doctorWorkingHoursService;
            _localizer = localizer;
        }
        [HttpPost("add")]
        public async Task<IActionResult> AddWorkingHoursAsync([FromBody] DoctorWorkingHoursRequestDTO request)
        {
            var doctorId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            //var workingHour = request.Adapt<DoctorWorkingHours>();
            int addedWorkingHour = await _doctorWorkingHoursService.AddWorkingHoursAsync(doctorId, request);
            if (addedWorkingHour > 0)
            {
                return Ok(new { Message = _localizer["Success"].Value });
            }
            return BadRequest(new { Message = _localizer["ExistingWorkingHours"].Value });

        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateWorkingHoursAsync([FromRoute] int id, [FromBody] DoctorWorkingHoursRequestDTO request)
        {

            int updatedvalue = await _doctorWorkingHoursService.UpdateWorkingHoursAsync(id, request);
            if (updatedvalue > 0)
            {
                return Ok(new { Message = _localizer["SuccessAdd"].Value });
            }

            return BadRequest(new { Message = _localizer["NoWorkingHours"].Value });

        }
    }
}
