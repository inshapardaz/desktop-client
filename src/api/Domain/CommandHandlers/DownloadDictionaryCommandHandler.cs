using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Common;
using Inshapardaz.Desktop.Common.Exceptions;
using Inshapardaz.Desktop.Common.Http;
using Inshapardaz.Desktop.Common.Models;
using Inshapardaz.Desktop.Domain.Command;
using Paramore.Brighter;

namespace Inshapardaz.Desktop.Domain.CommandHandlers
{
    public class DownloadDictionaryCommandHandler : RequestHandlerAsync<DownloadDictionaryCommand>
    {
        private readonly IApiClient _apiClient;
        private readonly IProvideUserSettings _userSettings;

        public DownloadDictionaryCommandHandler(IApiClient apiClient, IProvideUserSettings userSettings)
        {
            _apiClient = apiClient;
            _userSettings = userSettings;
        }
        public override async Task<DownloadDictionaryCommand> HandleAsync(DownloadDictionaryCommand command, CancellationToken cancellationToken = new CancellationToken())
        {
            var dictionary = await _apiClient.Get<DictionaryModel>($"api/dictionaries/{command.DictionaryId}");
            var downloadLink = dictionary.Links.SingleOrDefault(l => l.Rel == RelTypes.Download);
            if (downloadLink == null)
            {
                throw new NotFoundException();
            }

            var stream = await _apiClient.GetStream(downloadLink.Href.AbsoluteUri);
            var filePath = Path.Combine(_userSettings.DictionariesFolder, $"{command.DictionaryId}.dat");
            using (var file = new FileStream(filePath, FileMode.Create))
            {
                stream.CopyTo(file);
            }

            stream.Dispose();

            command.Result = dictionary;
            command.FilePath = filePath;
            return await base.HandleAsync(command, cancellationToken);
        }
    }
}
