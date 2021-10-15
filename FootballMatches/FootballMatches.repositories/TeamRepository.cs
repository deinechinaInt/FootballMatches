using System;
using System.Linq;
using System.Threading.Tasks;
using FootballMatches.Domain;
using Microsoft.EntityFrameworkCore;

namespace FootballMatches.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private readonly FootballMatchesContext _context;

        public TeamRepository(FootballMatchesContext context)
        {
            _context = context;
        }

        public async Task<Team[]> GetAllTeamsAsync()
        {
            IQueryable<Team> query = _context.Teams.Include(c => c.Players);

            return await query.ToArrayAsync();
        }

        public async Task<Team> GetTeamByIdAsync(int id)
        {
            IQueryable<Team> query = _context.Teams.Include(c => c.Players);

            query = query.Where(c => c.Id == id);

            return await query.FirstOrDefaultAsync();
        }
    }
}
