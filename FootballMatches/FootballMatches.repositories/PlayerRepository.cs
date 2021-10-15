using System;
using System.Linq;
using System.Threading.Tasks;
using FootballMatches.Domain;
using Microsoft.EntityFrameworkCore;

namespace FootballMatches.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly FootballMatchesContext _context;

        public PlayerRepository(FootballMatchesContext context)
        {
            _context = context;
        }

        public async Task<Player[]> GetAllPlayersAsync(int teamId)
        {
            IQueryable<Player> query = _context.Players;

            query = query.Where(c => c.TeamId == teamId);

            return await query.ToArrayAsync();
        }

        public async Task<Player> GetPlayerByIdAsync(int teamId, int id)
        {
            IQueryable<Player> query = _context.Players;

            query = query.Where(c => c.Id == id && c.TeamId == teamId);

            return await query.FirstOrDefaultAsync();
        }

        public void AddPlayer(Player player)
        {
            _context.Players.Add(player);
        }

        public async Task<bool> SaveChangesAsync()
        {
            // Only return success if at least one row was changed
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
