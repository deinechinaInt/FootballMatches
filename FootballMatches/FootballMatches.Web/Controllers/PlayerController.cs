using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FootballMatches.Domain;
using FootballMatches.Repositories;
using FootballMatches.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace FootballMatches.Web.Controllers
{
    [ApiController]
    [Route("api/teams/{teamId}/players")]
    public class PlayerController: ControllerBase
    {
        private readonly IPlayerRepository _repository;

        private readonly ITeamRepository _teamRepository;

        private readonly IMapper _mapper;

        public PlayerController(IPlayerRepository repository, IMapper mapper, ITeamRepository teamRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _teamRepository = teamRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPlayers(int teamId)
        {
            var result = await _repository.GetAllPlayersAsync(teamId);
            if (result == null)
            {
                return NotFound();
            }

            var mappedResult = _mapper.Map<IEnumerable<PlayerModel>>(result);

            return Ok(mappedResult);
        }

        [HttpGet("{id}", Name ="GetPlayer")]
        public async Task<IActionResult> GetPlayer(int teamId, int id)
        {
            var result = await _repository.GetPlayerByIdAsync(teamId, id);
            if (result == null)
            {
                return NotFound();
            }

            var mappedResult = _mapper.Map<PlayerModel>(result);

            return Ok(mappedResult);
        }

        [HttpPost]
        public async Task<IActionResult> Post(int teamId, PlayerModel model)
        {
            if (ModelState.IsValid)
                {
                    var team = await _teamRepository.GetTeamByIdAsync(teamId);
                    if (team != null)
                    {
                        var player = _mapper.Map<Player>(model);
                        player.Team = team;                       

                        _repository.AddPlayer(player);

                        if (await _repository.SaveChangesAsync())
                        {
                            return CreatedAtRoute("GetPlayer", new { teamId = teamId, id = player.Id }, _mapper.Map<PlayerModel>(player));
                        }
                    }

                }
           
            return BadRequest(ModelState);
        }

    }
}
