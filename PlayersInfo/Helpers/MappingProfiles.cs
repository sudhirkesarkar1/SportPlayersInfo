using AutoMapper;
using PlayersInfo.Dtos;
using PlayersInfo.EntityModelsData.Models.Entities;

namespace PlayersInfo.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Player, PlayerToReturnDto>()
                .ForMember(d => d.CountryInfo, o => o.MapFrom(s => s.CountryInfo.Name))
                .ForMember(d => d.GameInfo, o => o.MapFrom(s => s.GameInfo.Name))
                .ForMember(dest => dest.Age, opt =>
                {
                    opt.MapFrom(d => d.DateOfBirth.CalculateAge());
                });
        }
    }
}