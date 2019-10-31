﻿using AutoMapper;
using Cuestionario.Model;

namespace Cuestionario.Services.DTO.Profiles
{
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
