using HealthCare.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare.PL.Areas.Finance
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;

        public InvoicesController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [HttpGet("{visitId}")]
        public async Task<IActionResult> GetInvoiceVisit([FromRoute] int visitId)
        {
            var result = await _invoiceService.GetInvoiceByVisitIdAsync(visitId);
            return Ok(result);
        }
    }
}
