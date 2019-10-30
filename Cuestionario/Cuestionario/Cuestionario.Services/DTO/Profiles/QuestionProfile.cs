using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Cuestionario.Model;

namespace Cuestionario.Services.DTO.Profiles
{
    public class QuestionProfile : Profile
    {
        public QuestionProfile()
        {
            CreateMap<Question, QuestionData>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Difficulty, opt => opt.Ignore())
                .ForMember(dest => dest.Answers, opt => opt.Ignore());

            CreateMap<Category, CategoryData>()
              .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
              .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));
            //.ForMember(dest => dest.Answers, opt => opt.MapFrom(src => src.Answers));
        }
    }
}
