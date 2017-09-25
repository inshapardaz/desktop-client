using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Domain.Command;
using Inshapardaz.Desktop.Domain.Contexts;
using Microsoft.Extensions.Configuration;
using Paramore.Brighter;

namespace Inshapardaz.Desktop.Domain.CommandHandlers
{
    public class MakeDictionaryOfflineCommandHandler : RequestHandlerAsync<MakeDictionaryOfflineCommand>
    {
        private readonly IApplicationDatabase _applicationDatabase;
        private readonly IConfigurationRoot _configuration;

        public MakeDictionaryOfflineCommandHandler(IApplicationDatabase applicationDatabase, IConfigurationRoot configuration)
        {
            _applicationDatabase = applicationDatabase;
            _configuration = configuration;
        }

        public override Task<MakeDictionaryOfflineCommand> HandleAsync(MakeDictionaryOfflineCommand command, CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }
    }
}
