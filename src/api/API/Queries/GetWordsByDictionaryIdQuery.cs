using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Api.Models;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Api.Queries
{
    public class GetWordsByDictionaryIdQuery : IQuery<PageView<WordView>>
    {
        public int Id { get; set; }
        public int PageNumber { get; set; } = 1;

        public int PageSize { get; set; } = 10;
    }

    public class GetWordsByDictionaryIdQueryHandler : QueryHandlerAsync<GetWordsByDictionaryIdQuery, PageView<WordView>>
    {
        public override async Task<PageView<WordView>> ExecuteAsync(GetWordsByDictionaryIdQuery query, CancellationToken cancellationToken = new CancellationToken())
        {
            return await ApiClient.Get<PageView<WordView>>($"api/dictionaries/{query.Id}/words?pageNumber={query.PageNumber}&pageSize={query.PageSize}");
        }
    }
}