using System.Threading;
using Inshapardaz.Desktop.Domain.Command;
using Microsoft.Extensions.Logging;
using Paramore.Brighter;

namespace Inshapardaz.Desktop.Domain.Jobs
{
    public class DownloadDictionaryJob
    {
        private readonly IAmACommandProcessor _commandProcessor;
        private readonly ILogger<DownloadDictionaryJob> _logger;

        public DownloadDictionaryJob(IAmACommandProcessor commandProcessor, ILogger<DownloadDictionaryJob> logger)
        {
            _commandProcessor = commandProcessor;
            _logger = logger;
        }

        public void Execute(int dictionaryId)
        {
            _logger.LogDebug("Started downloading dictionary {0}", dictionaryId);
            var downloadDictionaryCommand = new DownloadDictionaryCommand
            {
                DictionaryId = dictionaryId
            };

            _commandProcessor.SendAsync(downloadDictionaryCommand).Wait();

            _logger.LogDebug("Dictionary {0} downloaded to {1}", dictionaryId, downloadDictionaryCommand.FilePath);

            _commandProcessor.SendAsync(new AddLocalDictionaryCommand
            {
                Dictionary = downloadDictionaryCommand.Result,
                FilePath = downloadDictionaryCommand.FilePath
            }).Wait();

            _logger.LogDebug("Finished downloading dictionary {0}", dictionaryId);
        }
    }
}
