using NetCoreAngularCRUD.Server.Data;
using NetCoreAngularCRUD.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace NetCoreAngularCRUD.Server.Services
{
    public class PlayersService(ESportTeamContext context) : IPlayersService
    {
        private readonly ESportTeamContext _context = context;

        public async Task<IEnumerable<Player>> GetPlayerList()
        {
            return await _context.Players
                .Include(x => x.Team)
                .ToListAsync();
        }

        public async Task<Player> GetPlayerById(int id)
        {
            return await _context.Players
                .Include(x => x.Team)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Player> CreatePlayer(Player player)
        {
            _context.Players.Add(player);
            await _context.SaveChangesAsync();
            return player;
        }

        public async Task UpdatePlayer(Player player)
        {
            _context.Players.Update(player);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePlayer(Player player)
        {
            _context.Players.Remove(player);
            await _context.SaveChangesAsync();
        }
    }
}
