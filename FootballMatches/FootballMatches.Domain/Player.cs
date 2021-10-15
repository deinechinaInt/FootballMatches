using System.ComponentModel.DataAnnotations;

namespace FootballMatches.Domain
{
    public class Player
    {
        public int Id { get; set; }

        [Required]       
        public string Name { get; set; }

        public Team Team { get; set; }

        public int TeamId { get; set; }
    }
}
