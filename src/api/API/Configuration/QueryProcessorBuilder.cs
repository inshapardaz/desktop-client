using System;
using System.Reflection;
using Inshapardaz.Desktop.Api.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Paramore.Darker.Builder;
using Paramore.Darker.Policies;
using Paramore.Darker.QueryLogging;
using Polly;

namespace API.Configuration
{
    public interface IConfigureQueryProcessor
    {
        INeedQueryHandlers UsingServices(IServiceCollection services);
    }

    public interface INeedQueryHandlers
    {
        INeedLocalQueryHandlers WithHandlers(bool online);
    }

    public interface INeedLocalQueryHandlers
    {
        IBuildQueryProcessor AndLocalHandlers();
    }
    
    public interface IBuildQueryProcessor
    {
        void Build();
    }

    public class QueryProcessorConfigurator : IConfigureQueryProcessor, INeedQueryHandlers, INeedLocalQueryHandlers, IBuildQueryProcessor
    {
        private IServiceCollection _services;
        private Assembly _handlerResolvingAssembly;
        private QueryProcessorConfigurator()
        {
        }

        public static IConfigureQueryProcessor Configure()
        {
            return new QueryProcessorConfigurator();
        }

        public INeedQueryHandlers UsingServices(IServiceCollection services)
        {
            _services = services;
            return this;
        }

        public INeedLocalQueryHandlers WithHandlers(bool online)
        {
            if (online)
            {
                Inshapardaz.Desktop.Api.Client.Module.RegisterQueryHandlers(_services);
                _handlerResolvingAssembly = typeof(Inshapardaz.Desktop.Api.Client.Module).GetTypeInfo().Assembly;
            }
            else
            {
                Inshapardaz.Desktop.Domain.Module.RegisterQueryHandlers(_services);
                _handlerResolvingAssembly = typeof(Inshapardaz.Desktop.Domain.Module).GetTypeInfo().Assembly;
            }

            return this;
        }


        public IBuildQueryProcessor AndLocalHandlers()
        {
            Inshapardaz.Desktop.Domain.Module.RegisterLocalDatabaseHandlers(_services);
            return this;
        }

        public void Build()
        {
            var config = new DarkerConfig(_services, _services.BuildServiceProvider());
            config.RegisterDefaultDecorators();
            config.RegisterQueriesAndHandlersFromAssembly(_handlerResolvingAssembly);

            var queryProcessor = QueryProcessorBuilder.With()
                .Handlers(config.HandlerRegistry, config, config)
                .InMemoryQueryContextFactory()
                .JsonQueryLogging()
                .Policies(ConfigurePolicies())
                .Build();

            _services.AddSingleton(queryProcessor);
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