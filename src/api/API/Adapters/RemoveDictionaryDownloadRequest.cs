using System;
using System.Threading;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Common.Exceptions;
using Inshapardaz.Desktop.Common.Queries;
using Inshapardaz.Desktop.Domain.Command;
using Paramore.Brighter;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Api.Adapters
{
    public class RemoveDictionaryDownloadRequest : IRequest
    {
        public RemoveDictionaryDownloadRequest(int dictionaryId)
        {
            DictionaryId = dictionaryId;
        }

        public Guid Id { get; set; }

        public int DictionaryId { get; set; }
    }

    public class RemoveDictionaryDownloadRequestHandler : RequestHandlerAsync<RemoveDictionaryDownloadRequest>
    {
        private readonly IAmACommandProcessor _commandProcessor;
        private readonly IQueryProcessor _queryProcessor;

        public RemoveDictionaryDownloadRequestHandler(IAmACommandProcessor commandProcessor, IQueryProcessor queryProcessor)
        {
            _commandProcessor = commandProcessor;
            _queryProcessor = queryProcessor;
        }

        public override async Task<RemoveDictionaryDownloadRequest> HandleAsync(RemoveDictionaryDownloadRequest command, CancellationToken cancellationToken = new CancellationToken())
        {
            var localDictionaryQuery = new GetLocalDictionaryQuery
            {
                DictionaryId = command.DictionaryId
            };
            var localDictionary = await _queryProcessor.ExecuteAsync(localDictionaryQuery, cancellationToken);

            if (localDictionary == null)
            {
                throw new NotFoundException();
            }

            await _commandProcessor.SendAsync(new RemoveLocalDictionaryCommand
            {
                DictionaryId = localDictionary.Id
            }, cancellationToken: cancellationToken);
            return await  base.HandleAsync(command, cancellationToken);
        }
    }
}
