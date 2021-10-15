using System;
using System.Threading.Tasks;
using FootballMatches.Domain;

namespace FootballMatches.Repositories
{
    public interface IFootballMatchRepository
    {
        Task<FootballMatch[]> GetAllMatchesAsync();

        Task<FootballMatch> GetMatchByIdAsync(int id);

        Task<FootballMatch[]> GetAllMatchesByEventDateAsync(DateTime dateTime);

        Task<FootballMatch[]> GetAllMatchesByPeriodAsync(DateTime firstDate, DateTime secondDate);

        Task<FootballMatch[]> GetAllMatchesByLocationAsync(int locationId);

        Task<FootballMatch[]> GetAllMatchesByTeamAsync(int teamId);

        Task<FootballMatch[]> GetAllMatchesByTeamPlayerAsync(int playerId);


    }
}