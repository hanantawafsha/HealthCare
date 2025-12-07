using HealthCare.BLL.Services.Interfaces;
using HealthCare.DAL.DTO.Requests;
using HealthCare.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace HealthCare.PL.Areas.Doctor
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Area("Doctor")]
    [Authorize(Roles = "Doctor")]
    public class VisitsController : ControllerBase
    {
        private readonly IVisitService _visitService;
        private readonly IStringLocalizer<SharedResource> _localizer;

        public VisitsController(IVisitService visitService,
            IStringLocalizer<SharedResource> localizer)
        {
            _visitService = visitService;
            _localizer = localizer;
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
            return Ok(new { Message = _localizer["SuccessAdded"].Value });
        }
        [HttpPost("addTreatment /{visitId}")]
        public async Task<IActionResult> AddTreatmentAsync([FromRoute] int visitId, TreatmentRequestDTO request)
        {
            var result = await _visitService.AddTreatmentAsync(visitId, request);
            return Ok(new { Message = _localizer["SuccessAdded"].Value });

        }
    }
}
