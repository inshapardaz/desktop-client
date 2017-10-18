using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Common.Models;
using Inshapardaz.Desktop.Common.Queries;
using Inshapardaz.Desktop.Domain.Contexts;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Domain.QueryHandlers
{
    public class GetLocalDictionariesQueryHandler : QueryHandlerAsync<GetLocalDictionariesQuery, DictionariesModel>
    {
        private readonly IApplicationDatabase _applicationDatabase;
        private readonly IQueryProcessor _queryProcessor;

        public GetLocalDictionariesQueryHandler(IApplicationDatabase applicationDatabase, IQueryProcessor queryProcessor)
        {
            _applicationDatabase = applicationDatabase;
            _queryProcessor = queryProcessor;
        }

        public override async Task<DictionariesModel> ExecuteAsync(GetLocalDictionariesQuery query, CancellationToken cancellationToken = new CancellationToken())
        {
            var dictionaries = new List<DictionaryModel>();
            ;
            foreach (var dictionary in _applicationDatabase.Dictionaries)
            {
                dictionaries.Add(await _queryProcessor.ExecuteAsync(new GetDictionaryByIdQuery{ Id = dictionary.Id }, cancellationToken));
            }


            return new DictionariesModel {Items = dictionaries};
        }
    }
}