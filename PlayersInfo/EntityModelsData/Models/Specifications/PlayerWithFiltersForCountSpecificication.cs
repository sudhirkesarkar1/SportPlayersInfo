using PlayersInfo.EntityModelsData.Models.Entities;

namespace PlayersInfo.EntityModelsData.Models.Specifications
{
    public class PlayerWithFiltersForCountSpecificication : BaseSpecification<Player>
    {
        public PlayerWithFiltersForCountSpecificication(PlayerSpecParams playerParams) 
            : base(x => 
                (string.IsNullOrEmpty(playerParams.Search) || x.Name.ToLower().Contains(playerParams.Search)) &&
                (!playerParams.CountryId.HasValue || x.CountryId == playerParams.CountryId) &&
                (!playerParams.GameId.HasValue || x.GameId == playerParams.GameId)
            )
        {
        }
    }
}