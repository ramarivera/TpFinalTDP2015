using AutoMapper;
using Questionnaire.Model;

namespace Questionnaire.Services.DTO.Profiles
{
    public class AnswerSessionProfile : Profile
    {
        public AnswerSessionProfile()
        {
            CreateMap<AnswerSession, AnswerSessionData>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category))
                .ForMember(dest => dest.Difficulty, opt => opt.MapFrom(src => src.Difficulty))
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username))
                .ForMember(dest => dest.Score, opt => opt.MapFrom(src => src.Score))
                .ForMember(dest => dest.StartTime, opt => opt.MapFrom(src => src.StartTime))
                .ForMember(dest => dest.EndTime, opt => opt.MapFrom(src => src.EndTime))
                .ForMember(dest => dest.UserAnswers, opt => opt.MapFrom(src => src.Answers));
        }
    }
}
