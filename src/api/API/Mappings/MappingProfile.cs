﻿using AutoMapper;
using Inshapardaz.Desktop.Api.Model;
using Inshapardaz.Desktop.Domain.Entities;

namespace Inshapardaz.Desktop.Api.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Setting, SettingsModel>()
                .ForMember(d => d.UserInterfaceLanguage, o => o.MapFrom(s => s.UserInterfaceLanguage))
                .ForMember(d => d.UseOffline, o => o.MapFrom(s => s.UseOffline))
                .ReverseMap()
                .ForMember(d => d.UserInterfaceLanguage, o => o.MapFrom(s => s.UserInterfaceLanguage))
                .ForMember(d => d.UseOffline, o => o.MapFrom(s => s.UseOffline));

        }
    }
}
