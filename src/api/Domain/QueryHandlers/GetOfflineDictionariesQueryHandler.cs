using System;
using System.Threading;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Common.Http;
using Inshapardaz.Desktop.Common.Models;
using Inshapardaz.Desktop.Common.Queries;
using Microsoft.Extensions.Configuration;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Domain.QueryHandlers
{
    public class GetOfflineDictionariesQueryHandler : QueryHandlerAsync<GetOfflineDictionariesQuery, DictionariesModel>
    {
        private readonly IApiClient _apiClient;
        private readonly IConfigurationRoot _configuration;

        public GetOfflineDictionariesQueryHandler(IApiClient apiClient, IConfigurationRoot configuration)
        {
            _configuration = configuration;
            _apiClient = apiClient;
        }
        public override async Task<DictionariesModel> ExecuteAsync(GetOfflineDictionariesQuery query, CancellationToken cancellationToken = new CancellationToken())
        {
            var baseUri = _configuration["offlineJsonUrl"];
            
            return await _apiClient.Get<DictionariesModel>(baseUri, null);
        }
    }
}