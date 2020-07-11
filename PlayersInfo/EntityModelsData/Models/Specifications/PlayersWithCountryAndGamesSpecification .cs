using PlayersInfo.EntityModelsData.Models.Entities;

namespace PlayersInfo.EntityModelsData.Models.Specifications
{
    public class PlayersWithCountryAndGamesSpecification : BaseSpecification<Player>
    {
        public PlayersWithCountryAndGamesSpecification (PlayerSpecParams playerParams): base(x => 
                (string.IsNullOrEmpty(playerParams.Search) || x.Name.ToLower().Contains(playerParams.Search)) &&
                (!playerParams.CountryId.HasValue || x.CountryId == playerParams.CountryId) &&
                (!playerParams.GameId.HasValue || x.GameId == playerParams.GameId)
            )
        {
            AddInclude(x=> x.CountryInfo);
            AddInclude(x=>x.GameInfo);
            AddOrderBy(x => x.Name);
            ApplyPaging(playerParams.PageSize * (playerParams.PageIndex - 1), playerParams.PageSize);
        }

        public PlayersWithCountryAndGamesSpecification (int id) : base( x => x.Id == id)
        {
            AddInclude(x=> x.CountryInfo);
            AddInclude(x=>x.GameInfo);
        }
    }
}