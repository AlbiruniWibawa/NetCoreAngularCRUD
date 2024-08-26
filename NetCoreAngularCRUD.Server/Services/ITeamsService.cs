using NetCoreAngularCRUD.Server.Models;

namespace NetCoreAngularCRUD.Server.Services
{
    public interface ITeamsService
    {
        Task<IEnumerable<Team>> GetTeamsList();
    }
}
