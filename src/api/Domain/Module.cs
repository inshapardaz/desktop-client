using Inshapardaz.Desktop.Domain.QueryHandlers;
using Microsoft.Extensions.DependencyInjection;

namespace Inshapardaz.Desktop.Domain
{
    public static class Module
    {
        public static void RegisterQueryHandlers(IServiceCollection services)
        {
            services.AddTransient<GetEntryQueryHandler>();
            services.AddTransient<GetDictionariesQueryHandler>();
            services.AddTransient<GetDictionaryByIdQueryHandler>();

            services.AddTransient<GetWordsByDictionaryIdQueryHandler>();
            services.AddTransient<GetWordByIdQueryHandler>();
            services.AddTransient<SearchWordsByDictionaryIdQueryHandler>();
            services.AddTransient<GetWordsStartingWithQueryHandler>();
            services.AddTransient<SearchWordsByTitleQueryHandler>();
            services.AddTransient<GetDetailsByWordIdQueryHandler>();
            services.AddTransient<GetDetailByIdQueryHandler>();
            services.AddTransient<GetMeaningByIdQueryHandler>();
            services.AddTransient<GetMeaningsByWordIdQueryHandler>();
            services.AddTransient<GetMeaningByContextQueryHandler>();
            services.AddTransient<GetRelationshipsByWordIdQueryHandler>();
            services.AddTransient<GetRelationshipByIdQueryHandler>();
            services.AddTransient<GetTranslationByIdQueryHandler>();
            services.AddTransient<GetTranslationsByWordIdQueryHandler>();
            services.AddTransient<GetTranslationsByLanguageQueryHandler>();
            services.AddTransient<GetAlternatesByWordIdQueryHandler>();

            services.AddTransient<GetLanguagesQueryHandler>();
            services.AddTransient<GetAttributesQueryHandler>();
            services.AddTransient<GetRelationshipTypesQueryHandler>();
        }
    }
}