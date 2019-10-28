using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Cuestionario.Model;

namespace Cuestionario.Services.DTO.Profiles
{
    public class AnswerProfile : Profile
    {
        public AnswerProfile()
        {
            CreateMap<Answer, AnswerData>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Correct, opt => opt.MapFrom(src => src.Correct))
                .ForMember(dest => dest.Question, opt => opt.MapFrom(src => src.Question));
        }
    }
}
