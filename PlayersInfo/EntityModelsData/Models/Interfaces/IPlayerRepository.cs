using System.Collections.Generic;
using System.Threading.Tasks;
using PlayersInfo.EntityModelsData.Models.Entities;

namespace PlayersInfo.EntityModelsData.Models.Interfaces
{
    public interface IPlayerRepository
    {
         Task<Player> GetPlayerByIdAsync(int id);
         Task<IReadOnlyList<Player>> GetPlayersAsync();
         Task<IReadOnlyList<Country>> GetCountriesAsync();
         Task<IReadOnlyList<Game>> GetGamesAsync();

    }
}