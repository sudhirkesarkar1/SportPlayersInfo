using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PlayersInfo.Dtos;
using PlayersInfo.EntityModelsData.Models.Entities;
using PlayersInfo.EntityModelsData.Models.Interfaces;

namespace PlayersInfo.Controllers 
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlayersController  : ControllerBase
    {
        private readonly IPlayerRepository _repo;
        private readonly IMapper _mapper;

        public PlayersController(IPlayerRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<PlayerToReturnDto>>> GetPlayers()
        {
            var players = await _repo.GetPlayersAsync();
            var playersToReturn = _mapper.Map<IReadOnlyList<Player>,IReadOnlyList<PlayerToReturnDto>>(players);
            return Ok(playersToReturn);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PlayerToReturnDto>> GetPlayert(int id)
        {
            var player = await _repo.GetPlayerByIdAsync(id);
            var playerToReturn = _mapper.Map<Player,PlayerToReturnDto>(player);
            return Ok(playerToReturn);
            // return Ok(player);
        }

        [HttpGet("countries")]
        public async Task<ActionResult<IReadOnlyList<Country>>> GetCountries()
        {
            return Ok(await _repo.GetCountriesAsync());
        }

        [HttpGet("games")]
        public async Task<ActionResult<IReadOnlyList<Game>>> GetGameTypes()
        {
            return Ok(await _repo.GetGamesAsync());
        }
    }
}