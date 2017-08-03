using System;
using Inshapardaz.Desktop.Api.Infrastructure;
using Inshapardaz.Desktop.Domain.Command;
using Inshapardaz.Desktop.Domain.CommandHandlers;
using Microsoft.Extensions.DependencyInjection;
using Paramore.Brighter;

namespace API.Configuration
{
    public interface IConfigureCommandProcessor
    {
        INeedRegistryToResolveHandlers UsingServices(IServiceCollection services);
    }
    
    public interface INeedRegistryToResolveHandlers
    {
        INeedHandlerRegistration WithRegistry();
    }

    public interface INeedHandlerRegistration
    {
        IBuildCommandProcessor RegisteringHandlers();
    }

    public interface IBuildCommandProcessor
    {
        void Build();
    }
    
    public class CommandProcessorConfigurator : IConfigureCommandProcessor, INeedRegistryToResolveHandlers, INeedHandlerRegistration, IBuildCommandProcessor
    {
        private SubscriberRegistry _subscriberRegistry;
        private IServiceCollection _services;

        private CommandProcessorConfigurator()
        {
        }

        public static IConfigureCommandProcessor Configure()
        {
            return new CommandProcessorConfigurator();
        }

        public INeedRegistryToResolveHandlers UsingServices(IServiceCollection services)
        {
            _services = services;
            return this;
        }

        public INeedHandlerRegistration WithRegistry()
        {
            _subscriberRegistry = new SubscriberRegistry();
            return this;
        }

        public IBuildCommandProcessor RegisteringHandlers()
        {
            _subscriberRegistry.RegisterAsync<UpdateSettingsCommand, UpdateSettingsCommandHandler>();
            _services.AddTransient<UpdateSettingsCommandHandler>();
            return this;
        }

        public void Build()
        {
            var commandProcessor = CommandProcessorBuilder.With()
                    .Handlers(new HandlerConfiguration(_subscriberRegistry,
                        new ServiceHandlerFactory(_services.BuildServiceProvider())))
                    .DefaultPolicy()
                    .NoTaskQueues()
                    .RequestContextFactory(new InMemoryRequestContextFactory())
                    .Build();

            _services.AddSingleton<IAmACommandProcessor>(commandProcessor);

        }
    }
}