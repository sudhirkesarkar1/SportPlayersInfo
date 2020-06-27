using System;

namespace PlayersInfo.EntityModelsData.Models.Entities
{
    public class Player : BaseEntity
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PictureUrl { get; set; }
        public int CountryId { get; set; }
        public Country CountryInfo { get; set; }
        public int GameId   {get;set;}
        public Game GameInfo { get; set; }
        
    }
}