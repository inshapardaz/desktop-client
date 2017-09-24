using AutoMapper;
using Inshapardaz.Data.Entities;
using Inshapardaz.Desktop.Common.Models;

namespace Inshapardaz.Desktop.Api.Mappings
{
    public class DomainMappings : Profile
    {
        public DomainMappings()
        {
            CreateMap<Dictionary, DictionaryModel>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.Name, o => o.MapFrom(s => s.Name))
                .ForMember(d => d.IsPublic, o => o.MapFrom(s => s.IsPublic))
                .ForMember(d => d.Language, o => o.MapFrom(s => s.Language))
                .ForMember(d => d.WordCount, o => o.Ignore())
                .ForMember(d => d.UserId, o => o.MapFrom(s => s.UserId))
                .ForMember(d => d.Links, o => o.Ignore())
                .ForMember(d => d.Indexes, o => o.Ignore());
            CreateMap<Word, WordModel>()
                .ForMember(d => d.Links, o => o.Ignore());

        }
    }
}
