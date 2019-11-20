using AutoMapper;
using Questionnaire.Model;

namespace Questionnaire.Services.DTO.Profiles
{
    /// <summary>
    /// Maps <see cref="Question"/> model class to <see cref="QuestionData"/> data transfer object using AutoMapper
    /// </summary>
    public class QuestionProfile : Profile
    {
        public QuestionProfile()
        {
            CreateMap<Question, QuestionData>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.QuestionType, opt => opt.MapFrom(src => src.QuestionType))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category))
                .ForMember(dest => dest.CorrectAnswer, opt => opt.MapFrom(src => src.CorrectAnswer))
                .ForMember(dest => dest.Difficulty, opt => opt.MapFrom(src => src.Difficulty))
                .ForMember(dest => dest.Answers, opt => opt.MapFrom(src => src.Answers));
        }
    }
}
