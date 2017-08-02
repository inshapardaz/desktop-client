using System;
using System.IO;
using System.Reflection;
using AutoMapper;
using Inshapardaz.Desktop.Api.Infrastructure;
using Inshapardaz.Desktop.Domain;
using Inshapardaz.Desktop.Domain.Command;
using Inshapardaz.Desktop.Domain.CommandHandlers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using Paramore.Brighter;
using Paramore.Darker.Builder;
using Paramore.Darker.Policies;
using Paramore.Darker.QueryLogging;
using Polly;
using PolicyRegistry = Paramore.Darker.Policies.PolicyRegistry;

namespace Inshapardaz.Desktop.Api
{
    public class Startup
    {
        private bool _useApi = false;

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

            services.AddTransient<IDatabase, Database>();

            RegisterBrighter(services); 
            RegisterDarker(services);
        }

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

        private static void RegisterBrighter(IServiceCollection services)
        {
            var registry = new SubscriberRegistry();
            registry.RegisterAsync<UpdateSettingsCommand, UpdateSettingsCommandHandler>();
            services.AddTransient<UpdateSettingsCommandHandler>();

            var commandProcessor = CommandProcessorBuilder.With()
                .Handlers(new HandlerConfiguration(registry,
                    new ServiceHandlerFactory(services.BuildServiceProvider())))
                .DefaultPolicy()
                .NoTaskQueues()
                .RequestContextFactory(new InMemoryRequestContextFactory())
                .Build();
            services.AddSingleton<IAmACommandProcessor>(commandProcessor);
        }

        private void RegisterDarker(IServiceCollection services)
        {
            Assembly handlerResolvingAssembly = null;
            if (_useApi)
            {
                Client.Module.RegisterQueryHandlers(services);
                handlerResolvingAssembly = typeof(Client.Module).GetTypeInfo().Assembly;
            }
            else
            {
                Domain.Module.RegisterQueryHandlers(services);
                handlerResolvingAssembly = typeof(Domain.Module).GetTypeInfo().Assembly;
            }

            Domain.Module.RegisterLocalDatabaseHandlers(services);
            var config = new DarkerConfig(services, services.BuildServiceProvider());
            config.RegisterDefaultDecorators();
            config.RegisterQueriesAndHandlersFromAssembly(handlerResolvingAssembly);

            var queryProcessor = QueryProcessorBuilder.With()
                .Handlers(config.HandlerRegistry, config, config)
                .InMemoryQueryContextFactory()
                .JsonQueryLogging()
                .Policies(ConfigurePolicies())
                .Build();

            services.AddSingleton(queryProcessor);
        }

        public static void ConfigureObjectMappings(IApplicationBuilder app)
        {
            Mapper.Initialize(c => c.AddProfile(new MappingProfile()));
            Mapper.AssertConfigurationIsValid();
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