using PlayersInfo.EntityModelsData.Models.Entities;

namespace PlayersInfo.Dtos
{
    public class PlayerToReturnDto
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string PictureUrl { get; set; }
        public string CountryInfo { get; set; }
        public string GameInfo { get; set; }
    }
}