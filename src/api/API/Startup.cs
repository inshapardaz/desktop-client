using System.IO;
using API.Configuration;
using AutoMapper;
using Inshapardaz.Desktop.Api.Mappings;
using Inshapardaz.Desktop.Api.Model;
using Inshapardaz.Desktop.Api.Renderers;
using Inshapardaz.Desktop.API.Renderers;
using Inshapardaz.Desktop.Common.Models;
using Inshapardaz.Desktop.Domain.Mappings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
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
            services.AddMvc().AddJsonOptions(options =>
                {
                    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddSingleton<IUrlHelperFactory, UrlHelperFactory>();
            
            Domain.Module.RegisterDatabases(services);
            RegisterRenderers(services);
            
            CommandProcessorConfigurator
                    .Configure()
                    .UsingServices(services)
                    .WithRegistry()
                    .RegisteringHandlers()
                    .Build();  
            
            QueryProcessorConfigurator
                    .Configure()
                    .UsingServices(services)
                    .WithHandlers(UseOffline)
                    .AndLocalHandlers()
                    .Build();
        }

        private bool UseOffline => bool.Parse(Configuration["useOffline"]);

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            ConfigureObjectMappings(app);

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

            Domain.Module.UpdateDatabase();
        }

        public void ConfigureObjectMappings(IApplicationBuilder app)
        {
            Mapper.Initialize(c => c.AddProfile(new MappingProfile()));

            if (UseOffline)
            {
                Mapper.Initialize(c => c.AddProfile(new DomainMappings()));
            }

            Mapper.AssertConfigurationIsValid();
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
            services.AddTransient<IRenderResponseFromObject<WordDetailModel, WordDetailView>, WordDetailRenderer>();
            services.AddTransient<IRenderResponseFromObject<MeaningModel, MeaningView>, MeaningRenderer>();
            services.AddTransient<IRenderResponseFromObject<RelationshipModel, RelationshipView>, RelationRenderer>();
            services.AddTransient<IRenderResponseFromObject<TranslationModel, TranslationView>, TranslationRenderer>();
        }
    }
}