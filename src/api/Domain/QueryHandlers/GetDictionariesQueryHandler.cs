using System;
using System.Threading;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Common.Models;
using Inshapardaz.Desktop.Common.Queries;
using Inshapardaz.Desktop.Domain.Contexts;
using Microsoft.EntityFrameworkCore;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Domain.QueryHandlers
{
    public class GetDictionariesQueryHandler : QueryHandlerAsync<GetDictionariesQuery, DictionariesModel>
    {
        private readonly IApplicationDatabase _applicationDatabase;

        public GetDictionariesQueryHandler(IApplicationDatabase applicationDatabase)
        {
            _applicationDatabase = applicationDatabase;
            //_dictionaryRenderer = dictionaryRenderer;
        }
        public override async Task<DictionariesModel> ExecuteAsync(GetDictionariesQuery query, CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
            //return _dictionaryRenderer.Render(await _applicationDatabase.Dictionaries.ToListAsync(cancellationToken));
        }
    }
}