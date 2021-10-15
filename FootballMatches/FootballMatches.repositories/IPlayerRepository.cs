using System.Threading.Tasks;
using FootballMatches.Domain;

namespace FootballMatches.Repositories
{
    public interface IPlayerRepository
    {
        Task<Player[]> GetAllPlayersAsync(int teamId);
        Task<Player> GetPlayerByIdAsync(int teamId, int id);

        void AddPlayer(Player player);

        Task<bool> SaveChangesAsync();
    }
}