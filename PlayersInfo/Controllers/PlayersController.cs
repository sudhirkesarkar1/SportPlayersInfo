using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PlayersInfo.Dtos;
using PlayersInfo.EntityModelsData.Models.Entities;
using PlayersInfo.EntityModelsData.Models.Interfaces;
using PlayersInfo.EntityModelsData.Models.Specifications;
using PlayersInfo.Errors;
using PlayersInfo.Helpers;

namespace PlayersInfo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlayersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Player> _playersRepo;
        private readonly IGenericRepository<Country> _countryRepo;
        private readonly IGenericRepository<Game> _gameRepo;
        public PlayersController(IGenericRepository<Player> playersRepo, IGenericRepository<Country> countryRepo, IGenericRepository<Game> gameRepo, IMapper mapper)
        {
            this._gameRepo = gameRepo;
            this._mapper = mapper;
            this._countryRepo = countryRepo;
            this._playersRepo = playersRepo;
        }

        [HttpGet]
        public async Task<ActionResult<Pagination<PlayerToReturnDto>>> GetPlayers([FromQuery]PlayerSpecParams playerParams)
        {
            var spec = new PlayersWithCountryAndGamesSpecification(playerParams);
            var countSpec = new PlayerWithFiltersForCountSpecificication(playerParams);
            var totalItems = await _playersRepo.CountAsync(countSpec);
            var players = await _playersRepo.ListAsync(spec);
            var playersToReturn = _mapper.Map<IReadOnlyList<Player>, IReadOnlyList<PlayerToReturnDto>>(players);
            var Paginations = new Pagination<PlayerToReturnDto>(playerParams.PageIndex,playerParams.PageSize,totalItems,playersToReturn);
            return Ok(Paginations);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PlayerToReturnDto>> GetPlayer(int id)
        {
            var spec = new PlayersWithCountryAndGamesSpecification(id);
            var player = await _playersRepo.GetEntityWithSpec(spec);
            var playerToReturn = _mapper.Map<Player, PlayerToReturnDto>(player);
            return Ok(playerToReturn);
            // return Ok(player);
        }

        [HttpGet("countries")]
        public async Task<ActionResult<IReadOnlyList<Country>>> GetCountries()
        {
            return Ok(await _countryRepo.ListAllAsync());
        }

        [HttpGet("games")]
        public async Task<ActionResult<IReadOnlyList<Game>>> GetGameTypes()
        {
            return Ok(await _gameRepo.ListAllAsync());
        }
    }
}