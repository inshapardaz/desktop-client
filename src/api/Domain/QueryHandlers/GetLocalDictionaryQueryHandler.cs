using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Common;
using Inshapardaz.Desktop.Common.Models;
using Inshapardaz.Desktop.Common.Queries;
using Inshapardaz.Desktop.Domain.Contexts;
using Inshapardaz.Desktop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Domain.QueryHandlers
{
    public class GetLocalDictionaryQueryHandler : QueryHandlerAsync<GetLocalDictionaryQuery, DictionaryModel>
    {
        private readonly IApplicationDatabase _applicationDatabase;

        public GetLocalDictionaryQueryHandler(IApplicationDatabase applicationDatabase)
        {
            _applicationDatabase = applicationDatabase;
        }

        public override async Task<DictionaryModel> ExecuteAsync(GetLocalDictionaryQuery query, CancellationToken cancellationToken = new CancellationToken())
        {
            return (await _applicationDatabase.Dictionaries
                                             .SingleOrDefaultAsync(d => d.Id == query.DictionaryId))
                                             .Map<Dictionary, DictionaryModel>();
        }
    }
}