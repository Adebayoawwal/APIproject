using APIproject.Solution.Enitities.Dto.Requests;
using AutoMapper;
using Solution.Enitities.dbSet;

namespace APIproject.MappingProfile
{
    public class RequestToDomain:Profile
    {
        public RequestToDomain()
        {
            CreateMap<CreateDriverAchievement, Achievement>()
            .ForMember(dest => dest.RaceWins,
            opt => opt.MapFrom(src => src.Wins))
            .ForMember(dest => dest.status,
            opt => opt.MapFrom(src => 1))
            .ForMember(dest => dest.AddedDate,
            opt => opt.MapFrom(src => DateTime.UtcNow))
             .ForMember(dest => dest.UpdatedDate,
            opt => opt.MapFrom(src => DateTime.UtcNow));


            CreateMap<UpdateDriverAchievementRequest, Achievement>()
            .ForMember(dest => dest.RaceWins,
            opt => opt.MapFrom(src => src.Wins))
          
             .ForMember(dest => dest.UpdatedDate,
            opt => opt.MapFrom(src => DateTime.UtcNow));
        }
    }
}
