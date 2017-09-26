using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Inshapardaz.Data;
using Inshapardaz.Data.Entities;
using Inshapardaz.Desktop.Common;
using Inshapardaz.Desktop.Common.Models;
using Inshapardaz.Desktop.Common.Queries;
using Microsoft.EntityFrameworkCore;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Domain.QueryHandlers
{
    public class GetRelationshipsByWordIdQueryHandler : QueryHandlerAsync<GetRelationshipsByWordIdQuery, IEnumerable<RelationshipModel>>
    {
        private readonly IDictionaryDatabase _database;

        public GetRelationshipsByWordIdQueryHandler(IDictionaryDatabase database)
        {
            _database = database;
        }

        public override async Task<IEnumerable<RelationshipModel>> ExecuteAsync(GetRelationshipsByWordIdQuery query, CancellationToken cancellationToken = new CancellationToken())
        {
            var relations = await _database.WordRelation
                                  .Include(r => r.RelatedWord)
                                  .Include(r => r.SourceWord)
                                  .Where(t => t.SourceWordId == query.WordId)
                                  .ToListAsync(cancellationToken);

            return relations.Select(r => r.Map<WordRelation, RelationshipModel>());
        }
    }
}