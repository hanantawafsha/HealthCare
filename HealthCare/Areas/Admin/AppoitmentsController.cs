using HealthCare.BLL.Services.Interfaces;
using HealthCare.DAL.DTO.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HealthCare.PL.Areas.Admin
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AppoitmentsController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppoitmentsController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }
        [HttpGet("")]
        public async Task<List<AppointmentDTO>> GetAll()
        {
            return await _appointmentService.GetAllwithPatientInfo();
        }
        [HttpPatch("changeStatus/{id}")]
        public async Task<IActionResult> UpdateStatus([FromRoute] int id, [FromBody] string status)
        {
            //var isAdmin = true;
            var result = await _appointmentService.UpdateStatusAsync(id, status, isAdmin: true);
            return Ok(result);
        }
        [HttpDelete("deleteAppointment/{id}")]
        public async Task<IActionResult> DeleteAppointment([FromRoute] int id)
        {
            var result = await _appointmentService.DeleteAsync(id);

            if (result == 0)
            {
                return NotFound(new { message = $"Appointment with ID {id} not found." });
            }
            return Ok(new { message = $"Appointment with ID {id} has been deleted successfully." });
        }
    }
}
