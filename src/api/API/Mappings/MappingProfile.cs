using AutoMapper;
using Inshapardaz.Desktop.Api.Model;
using Inshapardaz.Desktop.Common.Models;
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

            CreateMap<DictionariesModel, DictionariesView>()
                .ForMember(d => d.Items, o => o.MapFrom(s => s.Items))
                .ForMember(d => d.Links, o => o.Ignore());
            CreateMap<DictionaryModel, DictionaryView>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.IsOffline, o => o.Ignore())
                .ForMember(d => d.Indexes, o => o.Ignore())
                .ForMember(d => d.Links, o => o.Ignore());
            CreateMap<WordModel, WordView>()
                .ForMember(d => d.Links, o => o.Ignore());
            CreateMap<WordDetailModel, WordDetailView>()
                .ForMember(d => d.Links, o => o.Ignore());
            CreateMap<MeaningModel, MeaningView>()
                .ForMember(d => d.Links, o => o.Ignore());
            CreateMap<RelationshipModel, RelationshipView>()
                .ForMember(d => d.Links, o => o.Ignore());
            CreateMap<TranslationModel, TranslationView>()
                .ForMember(d => d.Links, o => o.Ignore());
        }
    }
}
