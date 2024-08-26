using NetCoreAngularCRUD.Server.Models;

namespace NetCoreAngularCRUD.Server.Services
{
    public interface IPlayersService
    {
        Task<IEnumerable<Player>> GetPlayerList();
        Task<Player> GetPlayerById(int id);
        Task<Player> CreatePlayer(Player player);
        Task UpdatePlayer(Player player);
        Task DeletePlayer(Player player);
    }
}
