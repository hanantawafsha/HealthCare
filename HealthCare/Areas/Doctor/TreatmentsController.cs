using HealthCare.BLL.Services.Interfaces;
using HealthCare.DAL.DTO.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare.PL.Areas.Doctor
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Area("Doctor")]
    [Authorize(Roles = "Doctor")]
    public class TreatmentsController : ControllerBase
    {
        private readonly ITreatmentSerivce _treatmentSerivce;

        public TreatmentsController(ITreatmentSerivce treatmentSerivce)
        {
            _treatmentSerivce = treatmentSerivce;
        }
        //[HttpGet("{visitId}")]
        //public async Task<IActionResult> AddTreatmentAsync([FromRoute] int visitId, TreatmentRequestDTO request)
        //{

        //}
    }
}
