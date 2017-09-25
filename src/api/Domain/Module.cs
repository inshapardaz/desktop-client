using System.IO;
using Inshapardaz.Data;
using Inshapardaz.Desktop.Common;
using Inshapardaz.Desktop.Domain.Contexts;
using Inshapardaz.Desktop.Domain.QueryHandlers;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Inshapardaz.Desktop.Domain
{
    public static class Module
    {
        public static void RegisterMappings()
        {
        }

        public static void UpdateDatabase(){
            using (var context = new ApplicationDatabase())
            {
                context.Database.Migrate();
            }
        }

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
            services.AddTransient<GetMeaningsByWordDetailIdQueryHandler>();
            services.AddTransient<GetMeaningByContextQueryHandler>();
            services.AddTransient<GetRelationshipsByWordIdQueryHandler>();
            services.AddTransient<GetRelationshipByIdQueryHandler>();
            services.AddTransient<GetTranslationByIdQueryHandler>();
            services.AddTransient<GetTranslationsByWordIdQueryHandler>();
            services.AddTransient<GetTranslationsByWordDetailIdQueryHandler>();
            services.AddTransient<GetTranslationsByLanguageQueryHandler>();
            services.AddTransient<GetAlternatesByWordIdQueryHandler>();

            services.AddTransient<GetLanguagesQueryHandler>();
            services.AddTransient<GetAttributesQueryHandler>();
            services.AddTransient<GetRelationshipTypesQueryHandler>();
        }

        public static void RegisterLocalDatabaseHandlers(IServiceCollection services)
        {
            services.AddTransient<GetSettingsQueryHandler>();            
        }

        public static void RegisterDatabases(IServiceCollection services, IProvideUserSettings settings)
        {
            var dictionariesFile = Path.Combine(settings.DataFolder, "dictionaries.dat");
            var dictionariesConnectionString = new SqliteConnectionStringBuilder { DataSource = dictionariesFile };

            var applicationDbFile = Path.Combine(settings.DataFolder, "application.dat");
            var applicationConnectionString = new SqliteConnectionStringBuilder { DataSource = applicationDbFile };

            services.AddEntityFrameworkSqlite()
                    .AddDbContext<DictionaryDatabase>(
                        options => options.UseSqlite(dictionariesConnectionString.ConnectionString))
                    .AddDbContext<ApplicationDatabase>(
                        options => options.UseSqlite(applicationConnectionString.ConnectionString));
            
            services.AddTransient<IApplicationDatabase, ApplicationDatabase>();
            services.AddTransient<IDictionaryDatabase, DictionaryDatabase>();
        }
    }
}