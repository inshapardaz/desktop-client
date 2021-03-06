﻿using System.Threading;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Common.Http;
using Inshapardaz.Desktop.Common.Models;
using Inshapardaz.Desktop.Common.Queries;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Api.Client.QueryHandlers
{
    public class SearchWordsByDictionaryIdQueryHandler : QueryHandlerAsync<SearchWordsByDictionaryIdQuery, PageModel<WordModel>>
    {
        private readonly IApiClient _apiClient;

        public SearchWordsByDictionaryIdQueryHandler(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }
        public override async Task<PageModel<WordModel>> ExecuteAsync(SearchWordsByDictionaryIdQuery query, CancellationToken cancellationToken = new CancellationToken())
        {
            return await _apiClient.Get<PageModel<WordModel>>($"api/dictionaries/{query.DictionaryId}/Search?query={query.Query}pageNumber={query.PageNumber}&pageSize={query.PageSize}");
        }
    }
}