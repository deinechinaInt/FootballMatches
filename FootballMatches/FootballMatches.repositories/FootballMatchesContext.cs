using System;
using FootballMatches.Domain;
using Microsoft.EntityFrameworkCore;

namespace FootballMatches.Repositories
{
    public class FootballMatchesContext : DbContext
    {
        public DbSet<FootballMatch> FootballMatches { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }

        public FootballMatchesContext(DbContextOptions<FootballMatchesContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FootballMatch>().HasOne(e => e.FirstTeam).WithMany();
            modelBuilder.Entity<FootballMatch>().HasOne(e => e.SecondTeam).WithMany();


            modelBuilder.Entity<Location>()
                 .HasData(
                new Location()
                {
                    Id = 1,
                    Name = "Chisinau"                   
                },
                new Location()
                {
                    Id = 2,
                    Name = "Tiraspol"                   
                },
                new Location()
                {
                    Id = 3,
                    Name = "Anenii"
                });

            modelBuilder.Entity<Team>()
                .HasData(
               new Team()
               {
                   Id = 1,
                   Name = "Team 1"
               },
               new Team()
               {
                   Id = 2,
                   Name = "Team 2"
               },
               new Team()
               {
                   Id = 3,
                   Name = "Team 3"
               },
                new Team()
                {
                    Id = 4,
                    Name = "Team 4"
                },
               new Team()
               {
                   Id = 5,
                   Name = "Team 5"
               },
               new Team()
               {
                   Id = 6,
                   Name = "Team 6"
               });

            modelBuilder.Entity<Player>()
               .HasData(
              new Player()
              {
                  Id = 1,
                  Name = "Player 1",
                  TeamId = 1
              },
              new Player()
              {
                  Id = 2,
                  Name = "Player 2",
                  TeamId = 1
              },
              new Player()
              {
                  Id = 3,
                  Name = "Player 3",
                  TeamId = 2
              },
               new Player()
               {
                   Id = 4,
                   Name = "Player 4",
                   TeamId = 3
               },
              new Player()
              {
                  Id = 5,
                  Name = "Player 5",
                  TeamId = 4
              },
              new Player()
              {
                  Id = 6,
                  Name = "Player 6",
                  TeamId = 3
              });

            modelBuilder.Entity<FootballMatch>()
                .HasData(
               new FootballMatch()
               {
                   Id = 1,
                  LocationId =1,
                  FirstTeamId =1,
                  SecondTeamId =2,
                  FirstTeamGoals =0,
                  SecondTeamGoals=1,
                  EventDate = new DateTime(2021, 1, 1)
               },
               new FootballMatch()
               {
                   Id = 2,
                   LocationId = 2,
                   FirstTeamId = 3,
                   SecondTeamId = 4,
                   FirstTeamGoals =5,
                   SecondTeamGoals = 1,
                   EventDate = new DateTime(2021, 1, 1)
               },
               new FootballMatch()
               {
                   Id = 3,
                   LocationId =3,
                   FirstTeamId = 5,
                   SecondTeamId = 6,
                   FirstTeamGoals = 3,
                   SecondTeamGoals = 2,
                   EventDate = new DateTime(2021, 1, 2)
               },
                new FootballMatch()
                {
                    Id = 4,
                    LocationId = 1,
                    FirstTeamId = 1,
                    SecondTeamId = 6,
                    FirstTeamGoals = 3,
                    SecondTeamGoals = 2,
                    EventDate = new DateTime(2021, 1, 2)
                },
                new FootballMatch()
                {
                    Id = 5,
                    LocationId = 1,
                    FirstTeamId = 2,
                    SecondTeamId = 6,
                    FirstTeamGoals = 4,
                    SecondTeamGoals = 5,
                    EventDate = new DateTime(2021, 1, 3)
                });

            base.OnModelCreating(modelBuilder);
        }

    }
}
