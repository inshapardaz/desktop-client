using System;
using System.Threading;
using System.Threading.Tasks;
using Hangfire;
using Inshapardaz.Desktop.Domain.Command;
using Inshapardaz.Desktop.Domain.Jobs;
using Microsoft.Extensions.Logging;
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
        private readonly IBackgroundJobClient _backgroundJobClient;
        private readonly ILogger<DownloadDictionaryRequestHandler> _logger;

        public DownloadDictionaryRequestHandler(IBackgroundJobClient backgroundJobClient, ILogger<DownloadDictionaryRequestHandler> logger)
        {
            _backgroundJobClient = backgroundJobClient;
            _logger = logger;
        }

        public override async Task<DownloadDictionaryRequest> HandleAsync(DownloadDictionaryRequest command, CancellationToken cancellationToken = new CancellationToken())
        {
            var jobId = _backgroundJobClient.Enqueue<DownloadDictionaryJob>(x => x.Execute(command.DictionaryId));
            _logger.LogInformation("Queued job {0} to download dictionary {1} as offline", jobId, command.DictionaryId);
            return await base.HandleAsync(command, cancellationToken);
        }
    }
}
