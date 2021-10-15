using AutoMapper;
using FootballMatches.Domain;

namespace FootballMatches.Web.Models
{
    public class FootballMatchesProfile : Profile
    {
        public FootballMatchesProfile()
        {
            CreateMap<FootballMatch, FootballMatchModel>()
                .ForMember(c => c.LocationName, opt => opt.MapFrom(m => m.Location.Name));


            CreateMap<Team, TeamModel>();

            CreateMap<Player, PlayerModel>().ReverseMap();
            
        }
       
    }
}
