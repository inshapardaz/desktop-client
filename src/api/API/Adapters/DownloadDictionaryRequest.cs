using System;
using System.Threading;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Domain.Command;
using Paramore.Brighter;

namespace Inshapardaz.Desktop.Api.Adapters
{
    public class DownloadDictionaryRequest : IRequest
    {
        public DownloadDictionaryRequest(int dictionaryId)
        {
            DictionaryId = dictionaryId;
        }

        public Guid Id { get; set; }

        public int DictionaryId { get; set; }
    }

    public class DownloadDictionaryRequestHandler : RequestHandlerAsync<DownloadDictionaryRequest>
    {
        private readonly IAmACommandProcessor _commandProcessor;

        public DownloadDictionaryRequestHandler(IAmACommandProcessor commandProcessor)
        {
            _commandProcessor = commandProcessor;
        }

        public override async Task<DownloadDictionaryRequest> HandleAsync(DownloadDictionaryRequest command, CancellationToken cancellationToken = new CancellationToken())
        {
            var downloadDictionaryCommand = new DownloadDictionaryCommand
            {
                DictionaryId = command.DictionaryId
            };
            await _commandProcessor.SendAsync(downloadDictionaryCommand, cancellationToken: cancellationToken);

            await _commandProcessor.SendAsync(new AddLocalDictionaryCommand
            {
                Dictionary = downloadDictionaryCommand.Result,
                FilePath = downloadDictionaryCommand.FilePath
            }, cancellationToken: cancellationToken);
            return await  base.HandleAsync(command, cancellationToken);
        }
    }
}
