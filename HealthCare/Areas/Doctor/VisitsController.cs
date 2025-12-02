using HealthCare.BLL.Services.Interfaces;
using HealthCare.DAL.DTO.Requests;
using HealthCare.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare.PL.Areas.Doctor
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitsController : ControllerBase
    {
        private readonly IVisitService _visitService;

        public VisitsController(IVisitService visitService)
        {
            _visitService = visitService;
        }
        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _visitService.GetAllAsync();
            return Ok(result);
        }
        [HttpPost("addVisit/{appointmentId}")]
        public async Task<IActionResult> AddVisitAsync([FromRoute] int appointmentId, VisitRequestDTO request)
        {
            var result = await _visitService.CreateVisitAsync(appointmentId, request);
            return Ok(result);
        }
        [HttpPost("addTreatment /{visitId}")]
        public async Task<IActionResult> AddTreatmentAsync([FromRoute] int visitId, TreatmentRequestDTO request)
        {
            var result = await _visitService.AddTreatmentAsync(visitId, request);
            return Ok(result);

        }
    }
}
