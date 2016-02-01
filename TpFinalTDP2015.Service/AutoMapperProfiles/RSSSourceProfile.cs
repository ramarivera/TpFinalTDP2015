﻿using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpFinalTDP2015.Service.DTO;
using TpFinalTDP2015.Model;

namespace TpFinalTDP2015.Service
{
    class RssSourceProfile: Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<RssSource, RssSourceDTO>()
              .ForMember(d => d.Id, o => o.MapFrom(c => c.Id))
              .ForMember(d => d.CreationDate, o => o.MapFrom(c => c.CreationDate))
              .ForMember(d => d.ModificationDate, o => o.MapFrom(c => c.LastModified))
              .ForMember(d => d.Title, o => o.MapFrom(c => c.Title))
              .ForMember(d => d.Description, o => o.MapFrom(c => c.Description))
              .ForMember(d => d.URL, o => o.MapFrom(c => c.URL))
              .ForMember(d => d.Items, o => o.MapFrom(c => c.Items));
        }
    }
}
