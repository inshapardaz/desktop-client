using System.Threading;
using System.Threading.Tasks;
using Inshapardaz.Desktop.Common.Models;
using Inshapardaz.Desktop.Common.Queries;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Database.Client.QueryHandlers
{
    public class GetDictionariesQueryHandler : QueryHandlerAsync<GetDictionariesQuery, DictionariesModel>
    {
        private readonly IQueryProcessor _queryProcessor;

        public GetDictionariesQueryHandler(IQueryProcessor queryProcessor)
        {
            _queryProcessor = queryProcessor;
        }

        public override async Task<DictionariesModel> ExecuteAsync(GetDictionariesQuery query, CancellationToken cancellationToken = new CancellationToken())
        {
            return await _queryProcessor.ExecuteAsync(new GetLocalDictionariesQuery(), cancellationToken);
            /*var dictionaries = new List<DictionaryModel>();
            foreach (var dictionary in _database.Dictionary)
            {
                dictionaries.Add(await GetDictionary(dictionary, cancellationToken));
            }

            return new DictionariesModel{ Items = dictionaries};
        }

        private async Task<DictionaryModel> GetDictionary(Dictionary dictionary, CancellationToken cancellationToken)
        {
            var result =  dictionary.Map<Dictionary, DictionaryModel>();
            result.WordCount = await _database.Word.CountAsync(w => w.DictionaryId == dictionary.Id, cancellationToken);
            return result;*/
        }
    }
}