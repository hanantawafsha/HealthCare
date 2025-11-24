using HealthCare.BLL.Services.Interfaces;
using HealthCare.DAL.DTO.Responses;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare.PL.Areas.Patient
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Area("Patient")]
    public class DoctorWorkingHourssController : Controller
    {
        private readonly IDoctorWorkingHoursService _doctorWorkingHoursService;

        public DoctorWorkingHourssController(IDoctorWorkingHoursService doctorWorkingHoursService)
        {
            _doctorWorkingHoursService = doctorWorkingHoursService;
        }
                

        [HttpGet("doctorworkinghours/{doctorId}")]
        public async Task<ActionResult<List<DoctorWorkingHoursResponseDTO>>> GetWorkingHours([FromRoute] string doctorId)
        {
            var result = await _doctorWorkingHoursService.GetDoctorWorkingSlotsAsync(doctorId);
            

            return Ok(result);
        }

    }
}
