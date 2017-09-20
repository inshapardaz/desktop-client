﻿using System.Threading;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Common.Models;
using Inshapardaz.Desktop.Common.Queries;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Api.Client.QueryHandlers
{
    public class GetWordsByDictionaryIdQueryHandler : QueryHandlerAsync<GetWordsByDictionaryIdQuery, PageModel<WordModel>>
    {
        public override async Task<PageModel<WordModel>> ExecuteAsync(GetWordsByDictionaryIdQuery query, CancellationToken cancellationToken = new CancellationToken())
        {
            return await ApiClient.Get<PageModel<WordModel>>($"api/dictionaries/{query.Id}/words?pageNumber={query.PageNumber}&pageSize={query.PageSize}");
        }
    }
}