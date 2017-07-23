using System;
using System.IO;
using System.Reflection;
using Inshapardaz.Desktop.Api.Infrastructure;
using Inshapardaz.Desktop.Api.Queries;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using Paramore.Darker.Builder;
using Paramore.Darker.Policies;
using Paramore.Darker.QueryLogging;
using Polly;

namespace Inshapardaz.Desktop.Api
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json", false, true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true, true);
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddJsonOptions(options =>
                {
                    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                });

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

            var config = new DarkerConfig(services, services.BuildServiceProvider());
            config.RegisterDefaultDecorators();
            config.RegisterQueriesAndHandlersFromAssembly(typeof(Startup).GetTypeInfo().Assembly);

            var queryProcessor = QueryProcessorBuilder.With()
                .Handlers(config.HandlerRegistry, config, config)
                .InMemoryQueryContextFactory()
                .JsonQueryLogging()
                .Policies(ConfigurePolicies())
                .Build();

            services.AddSingleton(queryProcessor);
        }

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
        }

        private IPolicyRegistry ConfigurePolicies()
        {
            var defaultRetryPolicy = Policy
                .Handle<Exception>()
                .WaitAndRetryAsync(new[]
                {
                    TimeSpan.FromMilliseconds(50),
                    TimeSpan.FromMilliseconds(100),
                    TimeSpan.FromMilliseconds(150)
                });

            var circuitBreakerPolicy = Policy
                .Handle<Exception>()
                .CircuitBreakerAsync(1, TimeSpan.FromMilliseconds(500));

            return new PolicyRegistry
            {
                { Paramore.Darker.Policies.Constants.RetryPolicyName, defaultRetryPolicy },
                { Paramore.Darker.Policies.Constants.CircuitBreakerPolicyName, circuitBreakerPolicy }
            };
        }
    }
}