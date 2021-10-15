using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FootballMatches.Web.Models
{
    public class FootballMatchModel
    {      
        public int Id { get; set; }

        public string LocationName { get; set; }

        public DateTime EventDate { get; set; } = DateTime.MinValue;

        public int FirstTeamGoals { get; set; }

        public int SecondTeamGoals { get; set; }

        public TeamModel  FirstTeam { get; set; }

        public TeamModel SecondTeam { get; set; }
    }
}
