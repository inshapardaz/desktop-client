using System;
using System.IO;
using System.Reflection;
using API.Configuration;
using AutoMapper;
using Inshapardaz.Desktop.Api.Infrastructure;
using Inshapardaz.Desktop.Api.Mappings;
using Inshapardaz.Desktop.Domain;
using Inshapardaz.Desktop.Domain.Command;
using Inshapardaz.Desktop.Domain.CommandHandlers;
using Inshapardaz.Desktop.Domain.Contexts;
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

            Domain.Module.RegisterDatabases(services);
            
            CommandProcessorConfigurator
                    .Configure()
                    .UsingServices(services)
                    .WithRegistry()
                    .RegisteringHandlers()
                    .Build();  
            
            QueryProcessorConfigurator
                    .Configure()
                    .UsingServices(services)
                    .WithHandlers(_useApi)
                    .AndLocalHandlers()
                    .Build();
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

        public static void ConfigureObjectMappings(IApplicationBuilder app)
        {
            Mapper.Initialize(c => c.AddProfile(new MappingProfile()));
            Mapper.AssertConfigurationIsValid();
        }
    }
}