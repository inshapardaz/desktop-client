using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Inshapardaz.Data.Entities;
using Inshapardaz.Desktop.Common;
using Inshapardaz.Desktop.Common.Models;
using Inshapardaz.Desktop.Common.Queries;
using Microsoft.EntityFrameworkCore;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Database.Client.QueryHandlers
{
    public class GetRelationshipsByWordIdQueryHandler : QueryHandlerAsync<GetRelationshipsByWordIdQuery, IEnumerable<RelationshipModel>>
    {
        private readonly IProvideDatabase _databaseProvider;

        public GetRelationshipsByWordIdQueryHandler(IProvideDatabase databaseProvider)
        {
            _databaseProvider = databaseProvider;
        }

        public override async Task<IEnumerable<RelationshipModel>> ExecuteAsync(GetRelationshipsByWordIdQuery query, CancellationToken cancellationToken = new CancellationToken())
        {
            using (var database = _databaseProvider.GetDatabaseForDictionary(query.DictionaryId))
            {
                var relations = await database.WordRelation
                                               .Include(r => r.RelatedWord)
                                               .Include(r => r.SourceWord)
                                               .Where(t => t.SourceWordId == query.WordId)
                                               .ToListAsync(cancellationToken);

                return relations.Select(r => r.Map<WordRelation, RelationshipModel>());
            }
        }
    }
}