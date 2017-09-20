using System;
using System.Threading;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Common.Models;
using Inshapardaz.Desktop.Common.Queries;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Domain.QueryHandlers
{
    public class GetWordsByDictionaryIdQueryHandler : QueryHandlerAsync<GetWordsByDictionaryIdQuery, PageModel<WordModel>>
    {
        public override Task<PageModel<WordModel>> ExecuteAsync(GetWordsByDictionaryIdQuery query, CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }
    }
}