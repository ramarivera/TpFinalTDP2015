using AutoMapper;
using Questionnaire.Model;

namespace Questionnaire.Services.DTO.Profiles
{
    /// <summary>
    /// Maps <see cref="Answer"/> model class to <see cref="AnswerData"/> data transfer object using AutoMapper
    /// </summary>
    public class AnswerProfile : Profile
    {
        public AnswerProfile()
        {
            CreateMap<Answer, AnswerData>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Question, opt => opt.MapFrom(src => src.Question));
        }
    }
}
