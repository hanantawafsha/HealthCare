using HealthCare.BLL.Services.Classes;
using HealthCare.BLL.Services.Interfaces;
using HealthCare.DAL.DTO.Requests;
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
    public class TreatmentsController : ControllerBase
    {
        private readonly ITreatmentSerivce _treatmentSerivce;
        private readonly IStringLocalizer<SharedResource> _localizer;


        public TreatmentsController(ITreatmentSerivce treatmentSerivce,
            IStringLocalizer<SharedResource> localizer)
        {
            _treatmentSerivce = treatmentSerivce;
            _localizer = localizer;
        }
        [HttpPost("addTreatment/{visitId}")]
        public async Task<IActionResult> AddTreatmentAsync([FromRoute] int visitId,[FromBody] TreatmentRequestDTO request)
        {
            var result =  await _treatmentSerivce.AddTreatmentAsync(visitId, request);
            return Ok(new { Message = _localizer["SuccessAdded"].Value });
        }
    }
}
