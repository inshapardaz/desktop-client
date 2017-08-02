using System;
using Paramore.Brighter;

namespace Inshapardaz.Desktop.Api.Infrastructure
{
    internal class ServiceHandlerFactory : IAmAHandlerFactoryAsync
    {
        private readonly IServiceProvider _serviceProvider;

        public ServiceHandlerFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        IHandleRequestsAsync IAmAHandlerFactoryAsync.Create(Type handlerType)
        {
            return _serviceProvider.GetService(handlerType) as IHandleRequestsAsync;
        }

        public void Release(IHandleRequestsAsync handler)
        {
            var disposable = handler as IDisposable;
            if (disposable != null)
            {
                disposable.Dispose();
            }
            handler = null;
        }
    }
}
