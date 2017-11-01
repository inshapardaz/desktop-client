using System.IO;
using System.Reflection;
using AutoMapper;
using Inshapardaz.Desktop.Api.Client;
using Inshapardaz.Desktop.Api.Helpers;
using Inshapardaz.Desktop.Api.Mappings;
using Inshapardaz.Desktop.Api.Model;
using Inshapardaz.Desktop.Api.Renderers;
using Inshapardaz.Desktop.Common;
using Inshapardaz.Desktop.Common.Http;
using Inshapardaz.Desktop.Common.Models;
using Inshapardaz.Desktop.Database.Client;
using Inshapardaz.Desktop.Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Paramore.Brighter.AspNetCore;
using Paramore.Darker.AspNetCore;
using DictionariesView = Inshapardaz.Desktop.Api.Model.DictionariesView;
using DictionaryView = Inshapardaz.Desktop.Api.Model.DictionaryView;

namespace Inshapardaz.Desktop.Api
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; set; }


        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json", false, true)
                   .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true, true);
            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSingleton(provider => Configuration);
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddSingleton<IUrlHelperFactory, UrlHelperFactory>();
            services.AddSingleton<IProvideUserSettings, UserSettings>();
            
            DomainModule.RegisterDatabases(services, new UserSettings());
            RegisterRenderers(services);

            if (UseOffline)
            {
                DatabaseClientModule.RegisterDatabases(services, new UserSettings());

                services.AddBrighter()
                        .AsyncHandlersFromAssemblies(typeof(DomainModule).GetTypeInfo().Assembly);
                services.AddDarker()
                        .AddHandlersFromAssemblies(
                            typeof(DatabaseClientModule).GetTypeInfo().Assembly,
                            typeof(DomainModule).GetTypeInfo().Assembly
                        );

                Mapper.Initialize(c =>
                    {
                        c.AddProfile(new MappingProfile());
                        c.AddProfile(new DatabaseClientMappings());
                    }
                );
            }
            else
            {
                services.AddTransient<IApiClient, ApiClient>();
                services.AddBrighter()
                        .AsyncHandlersFromAssemblies(
                            typeof(ApiClientModule).GetTypeInfo().Assembly,
                            typeof(DomainModule).GetTypeInfo().Assembly);
                services.AddDarker()
                        .AddHandlersFromAssemblies(
                            typeof(DomainModule).GetTypeInfo().Assembly,
                            typeof(ApiClientModule).GetTypeInfo().Assembly);

                Mapper.Initialize(c => c.AddProfile(new MappingProfile()));
            }

            Mapper.AssertConfigurationIsValid();
        }

        private bool UseOffline => bool.Parse(Configuration["useOffline"]);

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            app.Use(async (context, next) =>
            {
                await next();
                if (context.Response.StatusCode == 404 &&
                    !Path.HasExtension(context.Request.Path.Value) &&
                    !context.Request.Path.Value.StartsWith("/api"))
                {
                    context.Request.Path = "/";
                    await next();
                }
            });

            app.UseCors(policy => policy.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());

            app.UseMvc();

            Domain.DomainModule.UpdateDatabase(new UserSettings());
        }

        public static void RegisterRenderers(IServiceCollection services)
        {
            services.AddTransient<IRenderLink, LinkRenderer>();
            services.AddTransient<IRenderEnum, EnumRenderer>();
            services.AddTransient<IRenderResponseFromObject<EntryModel, EntryView>, EntryRenderer>();
            services.AddTransient<IRenderResponseFromObject<DictionariesModel, DictionariesView>, DictionariesRenderer>();
            services.AddTransient<IRenderResponseFromObject<PageRendererArgs<WordModel>, PageView<WordView>>, PageRenderer>();
            services.AddTransient<IRenderResponseFromObject<DictionaryModel, DictionaryView>, DictionaryRenderer>();
            services.AddTransient<IRenderResponseFromObject<WordModel, WordView>, WordRenderer>();
            services.AddTransient<IRenderResponseFromObject<MeaningModel, MeaningView>, MeaningRenderer>();
            services.AddTransient<IRenderResponseFromObject<RelationshipModel, RelationshipView>, RelationRenderer>();
            services.AddTransient<IRenderResponseFromObject<TranslationModel, TranslationView>, TranslationRenderer>();
        }
    }
}