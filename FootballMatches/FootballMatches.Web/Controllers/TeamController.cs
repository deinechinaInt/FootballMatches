using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FootballMatches.Repositories;
using FootballMatches.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace FootballMatches.Web.Controllers
{
    [ApiController]
    [Route("api/teams")]
    public class TeamController: ControllerBase
    {
        private readonly ITeamRepository _repository;

        private readonly IMapper _mapper;

        public TeamController(ITeamRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTeams()
        {
            var result = await _repository.GetAllTeamsAsync();
            if (result == null)
            {
                return NotFound();
            }

            var mappedResult = _mapper.Map<IEnumerable<TeamModel>>(result);

            return Ok(mappedResult);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeam(int id)
        {
            var result = await _repository.GetTeamByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }

            var mappedResult = _mapper.Map<TeamModel>(result);

            return Ok(mappedResult);
        }

    }
}
