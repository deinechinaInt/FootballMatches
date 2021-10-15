using System.Threading.Tasks;
using FootballMatches.Domain;

namespace FootballMatches.Repositories
{
    public interface ITeamRepository
    {
        Task<Team[]> GetAllTeamsAsync();

        Task<Team> GetTeamByIdAsync(int id);
    }
}
