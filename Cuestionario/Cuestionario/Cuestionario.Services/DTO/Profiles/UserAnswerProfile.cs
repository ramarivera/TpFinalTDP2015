using AutoMapper;
using Questionnaire.Model;

namespace Questionnaire.Services.DTO.Profiles
{
    public class UserAnswerProfile : Profile
    {
        public UserAnswerProfile()
        {
            CreateMap<UserAnswer, UserAnswerData>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Question, opt => opt.MapFrom(src => src.Question))
                .ForMember(dest => dest.AnswerSession, opt => opt.MapFrom(src => src.AnswerSession))
                .ForMember(dest => dest.ChosenAnswer, opt => opt.MapFrom(src => src.ChosenAnswer));
        }
    }
}
