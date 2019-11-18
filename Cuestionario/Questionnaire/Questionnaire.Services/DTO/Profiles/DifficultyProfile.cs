using AutoMapper;
using Questionnaire.Model;

namespace Questionnaire.Services.DTO.Profiles
{
    /// <summary>
    /// Maps <see cref="Difficulty"/> model class to <see cref="DifficultyData"/> data transfer object using AutoMapper
    /// </summary>
    public class DifficultyProfile : Profile
    {
        public DifficultyProfile()
        {
            CreateMap<Difficulty, DifficultyData>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Questions, opt => opt.Ignore());
        }
    }
}
