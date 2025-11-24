using HealthCare.BLL.Services.Interfaces;
using HealthCare.DAL.DTO.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace HealthCare.PL.Areas.Admin
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IStringLocalizer<SharedResource> _localizer;

        public UsersController(IUserService userService,
             IStringLocalizer<SharedResource> localizer)
        {
            _userService = userService;
            _localizer = localizer;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AddressResponseDto>> GetAddress([FromRoute] string id)
        {
            var address = await _userService.GetAddressAsync(id);
            if (address == null)
            {
                return NotFound(new { Message = _localizer["AddressNotFound"].Value });
            }
            return Ok(address);
        }

    }
}
