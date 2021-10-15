using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FootballMatches.Repositories;
using FootballMatches.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace FootballMatches.Web.Controllers
{
    [ApiController]
    [Route("api/footballMatches")]
    public class FootballMatchController: ControllerBase
    {
        private readonly IFootballMatchRepository _repository;

        private readonly IMapper _mapper;

        public FootballMatchController(IFootballMatchRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

       

        [HttpGet]
        public async Task<IActionResult> GetAllFootballMatches()
        {        
                var result = await _repository.GetAllMatchesAsync();
                if (result == null)
                {
                    return NotFound();
                }

                var mappedResult = _mapper.Map<IEnumerable<FootballMatchModel>>(result);

                return Ok(mappedResult);            
        }

      
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFootballMatch(int id)
        {          
                var result = await _repository.GetMatchByIdAsync(id);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(_mapper.Map<FootballMatchModel>(result));           
        }

       
        [HttpGet("searchByDate/{eventDate:datetime}")]
        public async Task<IActionResult> SearchByEventDate(DateTime eventDate)
        {
           
            var result = await _repository.GetAllMatchesByEventDateAsync(eventDate);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<IEnumerable<FootballMatchModel>>(result));
           
        }

        [HttpGet("searchByPeriod/{firstDate:datetime}/{secondDate:datetime}")]
        public async Task<IActionResult> GetAllMatchesByPeriod(DateTime firstDate, DateTime secondDate)
        {

            var result = await _repository.GetAllMatchesByPeriodAsync(firstDate, secondDate);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<IEnumerable<FootballMatchModel>>(result));

        }

        [HttpGet("searchByLocation/{locationId:int}")]
        public async Task<IActionResult> SearchByLocation(int locationId)
        {

            var result = await _repository.GetAllMatchesByLocationAsync(locationId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<IEnumerable<FootballMatchModel>>(result));

        }

        [HttpGet("searchByTeam/{teamId:int}")]
        public async Task<IActionResult> SearchByTeam(int teamId)
        {

            var result = await _repository.GetAllMatchesByTeamAsync(teamId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<IEnumerable<FootballMatchModel>>(result));

        }


        [HttpGet("searchByPlayer/{playerId:int}")]
        public async Task<IActionResult> SearchByPlayer(int playerId)
        {

            var result = await _repository.GetAllMatchesByTeamPlayerAsync(playerId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<IEnumerable<FootballMatchModel>>(result));

        }

    }
}
