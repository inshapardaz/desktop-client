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
                .ForMember(d => d.WebHomeUrl, o => o.Ignore())
                .ForMember(d => d.UIFont, o => o.MapFrom(s => s.UIFont))
                .ReverseMap()
                .ForMember(d => d.UserInterfaceLanguage, o => o.MapFrom(s => s.UserInterfaceLanguage))
                .ForMember(d => d.UseOffline, o => o.MapFrom(s => s.UseOffline));

            CreateMap<Dictionary, DictionaryModel>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.Name, o => o.MapFrom(s => s.Name))
                .ForMember(d => d.IsPublic, o => o.MapFrom(s => s.IsPublic))
                .ForMember(d => d.Language, o => o.MapFrom(s => s.Language))
                .ForMember(d => d.WordCount, o => o.Ignore())
                .ForMember(d => d.UserId, o => o.MapFrom(s => s.UserId))
                .ForMember(d => d.IsOffline, o => o.UseValue(true))
                .ForMember(d => d.IsDownloading, o => o.UseValue(false))
                .ForMember(d => d.Links, o => o.Ignore())
                .ForMember(d => d.Indexes, o => o.Ignore());

            CreateMap<DictionariesModel, DictionariesView>()
                .ForMember(d => d.Items, o => o.MapFrom(s => s.Items))
                .ForMember(d => d.Links, o => o.Ignore());
            CreateMap<DictionaryModel, DictionaryView>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.IsOffline, o => o.MapFrom(s => s.IsOffline))
                .ForMember(d => d.IsDownloading, o => o.MapFrom(s => s.IsDownloading))
                .ForMember(d => d.Indexes, o => o.Ignore())
                .ForMember(d => d.Links, o => o.Ignore());

            CreateMap<DictionaryModel, Dictionary>()
                .ForMember(d => d.Name, o => o.MapFrom(s => s.Name))
                .ForMember(d => d.Language, o => o.MapFrom(s => s.Language))
                .ForMember(d => d.IsPublic, o => o.MapFrom(s => s.IsPublic))
                .ForMember(d => d.WordCount, o => o.MapFrom(s => s.WordCount))
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.FilePath, o => o.Ignore());
            CreateMap<WordModel, WordView>()
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
