using System.ComponentModel.DataAnnotations;

namespace FootballMatches.Domain
{
    public class Location
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
    }
}
