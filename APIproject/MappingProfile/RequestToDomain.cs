using APIproject.Solution.Enitities.Dto.Requests;
using APIproject.Solution.Enitities.Dto.responses;
using APIproject.Solution.Enitities.Dto.Responses;
using AutoMapper;
using Solution.Enitities.dbSet;

namespace APIproject.MappingProfile
{
    public class RequestToDomain:Profile
    {
        public RequestToDomain()
        {
            CreateMap<Achievement, DriverAchievementResponse>()
            .ForMember(dest => dest.Wins,
            opt => opt.MapFrom(src => src.RaceWins));




            CreateMap<Driver, GetDriverResponses>()
                 .ForMember(dest => dest.DriverId,
                     opt => opt.MapFrom(src => src.Id)

            .ForMember(dest => dest.FullName,
            opt => opt.MapFrom(src => src.FirstName);

        }
    }
}
