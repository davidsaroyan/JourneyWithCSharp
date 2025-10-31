using Microsoft.AspNetCore.Mvc;
using FootballApi.Services;
using FootballApi.Models.DTO;
using FootballApi.Common.DTO;
using Microsoft.AspNetCore.Authorization;

namespace FootballApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase 
    {
        private readonly AccountService _accountService;
        public AccountController(AccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(LoginResponse), StatusCodes.Status200OK)]
        public async Task<ActionResult<LoginResponse>> Login([FromBody]LoginRequest request)
        {
            var result = await _accountService.LoginAsync(request);
            if (result == null || result.Token is null) return NotFound("Wrong login Parameters");
            return Ok(result);
        }

        [HttpPost("RefreshToken")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(LoginResponse), StatusCodes.Status200OK)]
        public async Task<ActionResult<LoginResponse>> RefreshToken([FromBody] RefreshTokenRequest request)
        {
            var result = await _accountService.RefreshTokenAsync(request);
            if (result == null || result.Token is null) return NotFound("Wrong login Parameters");
            return Ok(result);
        }
    }
}
