using NetCoreAngularCRUD.Server.Models;
using NetCoreAngularCRUD.Server.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

namespace NetCoreAngularCRUD.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamsController(ITeamsService _teamService) : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<Team>> Get()
        {
            return await _teamService.GetTeamsList();
        }
    }
}
