using System.Threading;
using Inshapardaz.Desktop.Domain.Command;
using Paramore.Brighter;

namespace Inshapardaz.Desktop.Domain.Jobs
{
    public class DownloadDictionaryJob
    {
        private readonly IAmACommandProcessor _commandProcessor;

        public DownloadDictionaryJob(IAmACommandProcessor commandProcessor)
        {
            _commandProcessor = commandProcessor;
        }

        public void Execute(int dictionaryId)
        {
            var downloadDictionaryCommand = new DownloadDictionaryCommand
            {
                DictionaryId = dictionaryId
            };

            _commandProcessor.SendAsync(downloadDictionaryCommand).Wait();

            _commandProcessor.SendAsync(new AddLocalDictionaryCommand
            {
                Dictionary = downloadDictionaryCommand.Result,
                FilePath = downloadDictionaryCommand.FilePath
            }).Wait();
        }
    }
}
