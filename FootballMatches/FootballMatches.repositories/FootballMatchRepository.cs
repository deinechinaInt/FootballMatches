using System;
using System.Linq;
using System.Threading.Tasks;
using FootballMatches.Domain;
using Microsoft.EntityFrameworkCore;

namespace FootballMatches.Repositories
{
    public class FootballMatchRepository : IFootballMatchRepository
    {
        private readonly FootballMatchesContext _context;

        public FootballMatchRepository(FootballMatchesContext context)
        {
            _context = context;
        }

        public async Task<FootballMatch[]> GetAllMatchesAsync()
        {
            IQueryable<FootballMatch> query = _context.FootballMatches.Include(c => c.Location).Include(c => c.FirstTeam).Include(c => c.SecondTeam);

            query = query.OrderByDescending(c => c.EventDate);

            return await query.ToArrayAsync();
        }

        public async Task<FootballMatch> GetMatchByIdAsync(int id)
        {

            IQueryable<FootballMatch> query = _context.FootballMatches.Include(c => c.Location).Include(c => c.FirstTeam).Include(c => c.SecondTeam);
                         
                query = query.Where(c => c.Id == id);

                return await query.FirstOrDefaultAsync();            
        }

        public async Task<FootballMatch[]> GetAllMatchesByEventDateAsync(DateTime dateTime)
        {
            IQueryable<FootballMatch> query = _context.FootballMatches.Include(c => c.Location).Include(c => c.FirstTeam).Include(c => c.SecondTeam);
                     
            query = query.OrderByDescending(c => c.EventDate)
              .Where(c => c.EventDate == dateTime);

            return await query.ToArrayAsync();
        }

        public async Task<FootballMatch[]> GetAllMatchesByLocationAsync(int locationId)
        {
            IQueryable<FootballMatch> query = _context.FootballMatches.Include(c => c.Location).Include(c => c.FirstTeam).Include(c => c.SecondTeam);

            query = query.OrderByDescending(c => c.EventDate)
              .Where(c => c.LocationId == locationId);

            return await query.ToArrayAsync();
        }

        public async Task<FootballMatch[]> GetAllMatchesByTeamAsync(int teamId)
        {
            IQueryable<FootballMatch> query = _context.FootballMatches.Include(c => c.Location).Include(c => c.FirstTeam).Include(c => c.SecondTeam);

            query = query.OrderByDescending(c => c.EventDate)
              .Where(c => c.FirstTeamId == teamId || c.SecondTeamId == teamId);

            return await query.ToArrayAsync();
        }

        //query = query
        //  .Include(c => c.Talks.Select(t => t.Speaker));

        public async Task<FootballMatch[]> GetAllMatchesByTeamPlayerAsync(int playerId)
        {
            IQueryable<FootballMatch> query = _context.FootballMatches.Include(c => c.Location).Include(c => c.FirstTeam).Include(c => c.SecondTeam).Include(c => c.SecondTeam.Players).Include(c => c.FirstTeam.Players);
            
            query = query.OrderByDescending(c => c.EventDate)
              .Where(c => c.FirstTeam.Players.Any(p=>p.Id == playerId) || c.SecondTeam.Players.Any(p => p.Id == playerId));

            return await query.ToArrayAsync();
        }

        public async Task<FootballMatch[]> GetAllMatchesByPeriodAsync(DateTime firstDate, DateTime secondDate)
        {
            IQueryable<FootballMatch> query = _context.FootballMatches.Include(c => c.Location).Include(c => c.FirstTeam).Include(c => c.SecondTeam);

            query = query.OrderByDescending(c => c.EventDate)
              .Where(c => c.EventDate >= firstDate && c.EventDate <=secondDate);

            return await query.ToArrayAsync();
        }
    }
}
