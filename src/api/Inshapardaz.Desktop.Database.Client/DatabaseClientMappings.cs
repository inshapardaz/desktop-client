using AutoMapper;
using Inshapardaz.Data.Entities;
using Inshapardaz.Desktop.Common.Models;

namespace Inshapardaz.Desktop.Database.Client
{
    public class DatabaseClientMappings : Profile
    {
        public DatabaseClientMappings()
        {
            CreateMap<Dictionary, DictionaryModel>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.Name, o => o.MapFrom(s => s.Name))
                .ForMember(d => d.IsPublic, o => o.MapFrom(s => s.IsPublic))
                .ForMember(d => d.Language, o => o.MapFrom(s => s.Language))
                .ForMember(d => d.WordCount, o => o.Ignore())
                .ForMember(d => d.UserId, o => o.MapFrom(s => s.UserId))
                .ForMember(d => d.IsOffline, o => o.UseValue(true))
                .ForMember(d => d.Links, o => o.Ignore())
                .ForMember(d => d.Indexes, o => o.Ignore());
            CreateMap<Word, WordModel>()
                .ForMember(d => d.Links, o => o.Ignore());
            CreateMap<WordDetail, WordDetailModel>()
                .ForMember(d => d.AttributeValue, o => o.MapFrom(s => (int)s.Attributes))
                .ForMember(d => d.LanguageId, o => o.MapFrom(s => (int)s.Language))
                .ForMember(d => d.WordId, o => o.MapFrom(s => s.WordInstanceId))
                .ForMember(d => d.Links, o => o.Ignore());
            CreateMap<Translation, TranslationModel>()
                .ForMember(d => d.Links, o => o.Ignore())
                .ForMember(d => d.LanguageId, o => o.MapFrom(s => (int)s.Language));
            CreateMap<Meaning, MeaningModel>()
                .ForMember(d => d.Links, o => o.Ignore());
            CreateMap<WordRelation, RelationshipModel>()
                .ForMember(d => d.Links, o => o.Ignore())
                .ForMember(d => d.SourceWord, o => o.MapFrom(s => s.SourceWord.Title))
                .ForMember(d => d.RelatedWord, o => o.MapFrom(s => s.RelatedWord.Title))
                .ForMember(d => d.RelationTypeId, o => o.MapFrom(s => (int)s.RelationType));

        }
    }
}
