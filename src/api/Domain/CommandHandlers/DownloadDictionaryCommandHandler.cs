using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Common;
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
            var dictionary = await _apiClient.Get<DictionaryModel>($"/api/dictionaries/{command.DictionaryId}");

            var stream = await _apiClient.GetSqlite($"/api/dictionary/{command.DictionaryId}/download");
            using (var file = new FileStream(Path.Combine(_userSettings.DictionariesFolder, $"{command.DictionaryId}.dat"), FileMode.Create))
            {
                stream.CopyTo(file);
            }

            stream.Dispose();

            command.Result = dictionary;
            return await base.HandleAsync(command, cancellationToken);
        }
    }
}
