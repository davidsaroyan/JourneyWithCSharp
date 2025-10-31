using Microsoft.AspNetCore.Mvc;
using FootballApi.Services;
using FootballApi.Models.DTO;

namespace FootballApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamController : ControllerBase 
    {
        private readonly FootballService _footballService;
        public TeamController(FootballService footballService)
        {
            _footballService = footballService;
        }

        [HttpGet("{teamName}")]
        [ProducesResponseType(typeof(TeamInfo), StatusCodes.Status200OK)]
        public async Task<ActionResult<TeamInfo>> Get(string teamName)
        {
            var info = await _footballService.GetTeamInfoAsync(teamName);
            if (info == null) return NotFound("Team not found :(");
            return Ok(info);
        }
    }
}
