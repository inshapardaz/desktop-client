using AutoMapper;
using Inshapardaz.Desktop.Common.Models;
using Inshapardaz.Desktop.Domain.Entities;
using DictionaryView = Inshapardaz.Desktop.Api.Model.DictionaryView;

namespace Inshapardaz.Desktop.Domain.Mappings
{
    public class DomainMappings : Profile
    {
        public DomainMappings()
        {
            CreateMap<Dictionary, DictionaryView>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.Name, o => o.MapFrom(s => s.Name))
                .ForMember(d => d.IsPublic, o => o.MapFrom(s => s.IsPublic))
                .ForMember(d => d.Language, o => o.MapFrom(s => s.Language))
                .ForMember(d => d.WordCount, o => o.MapFrom(s => s.WordCount))
                .ForMember(d => d.UserId, o => o.MapFrom(s => s.UserId))
                .ForMember(d => d.Links, o => o.Ignore())
                .ForMember(d => d.Indexes, o => o.Ignore());
        }
    }
}
