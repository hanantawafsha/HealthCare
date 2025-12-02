using HealthCare.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace HealthCare.PL.Areas.Doctor
{
    [Route("api/[controller]")]
    [ApiController]
    [Area("Doctor")]

    public class DoctorScheduleController : ControllerBase
    {
        private readonly IDoctorScheduleService _doctorScheduleService;
        private readonly IStringLocalizer<SharedResource> _localizer;

        public DoctorScheduleController(IDoctorScheduleService doctorScheduleService,
            IStringLocalizer<SharedResource> localizer)
        {
            _doctorScheduleService = doctorScheduleService;
            _localizer = localizer;
        }
        [HttpGet("available-slots")]
        public async Task<IActionResult> GetAvailableSlots(string doctorId, DateTime date)
        {
            var result = await _doctorScheduleService.GetAvailableSlotsAsync(doctorId, date);

            if (!result.Any())
                return NotFound(new { Message = _localizer["NoAvailableSlots"].Value });

            return Ok(result);
        }

    }
}
