using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PlayersInfo.EntityModelsData.Models.Entities;
using PlayersInfo.EntityModelsData.Models.Interfaces;

namespace PlayersInfo.Controllers 
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlayersController  : ControllerBase
    {
        private readonly IPlayerRepository _repo;

        public PlayersController(IPlayerRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Player>>> GetPlayers()
        {
            var products = await _repo.GetPlayersAsync();

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Player>> GetPlayert(int id)
        {
            return await _repo.GetPlayerByIdAsync(id);
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