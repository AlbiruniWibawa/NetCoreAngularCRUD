using NetCoreAngularCRUD.Server.Data;
using NetCoreAngularCRUD.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace NetCoreAngularCRUD.Server.Services
{
    public class TeamsService(ESportTeamContext context) : ITeamsService
    {
        private readonly ESportTeamContext _context = context;

        public async Task<IEnumerable<Team>> GetTeamsList()
        {
            return await _context.Teams
                .OrderBy(t => t.Id)
                .Include(t => t.Players)
                .ToListAsync();
        }
    }
}
