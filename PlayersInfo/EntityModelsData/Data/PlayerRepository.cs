using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PlayersInfo.EntityModelsData.Models.Entities;
using PlayersInfo.EntityModelsData.Models.Interfaces;

namespace PlayersInfo.EntityModelsData.Data
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly ApiDbContext _context;
        public PlayerRepository(ApiDbContext context)
        {
            _context = context;
        }
        public async Task<IReadOnlyList<Country>> GetCountriesAsync()
        {
            return await _context.Countries.ToListAsync();
        }

        public async Task<IReadOnlyList<Game>> GetGamesAsync()
        {
            return await _context.Games.ToListAsync();
        }

        public async Task<Player> GetPlayerByIdAsync(int id)
        {
            return await _context.Players
                .Include(p => p.CountryInfo)
                .Include(p => p.GameInfo)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IReadOnlyList<Player>> GetPlayersAsync()
        {
            return await _context.Players
                .Include(p => p.CountryInfo)
                .Include(p => p.GameInfo)
                .ToListAsync();
        }
    }
}