using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootballMatches.Domain
{
    public class FootballMatch
    {
        [Key]
        public int Id { get; set; }

        public Location Location { get; set; }

        public int LocationId { get; set; }

        public DateTime EventDate { get; set; } = DateTime.MinValue;
        
        public int FirstTeamGoals { get; set; }

        public int SecondTeamGoals { get; set; }

        public int? FirstTeamId { get; set; }

        [ForeignKey("FirstTeamId")]      
        public Team FirstTeam { get; set; }

        public int? SecondTeamId { get; set; }

        [ForeignKey("SecondTeamId")]
        public Team SecondTeam { get; set; }

     
    }
}
