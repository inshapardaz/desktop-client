using System;
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
    public class GetRelationshipByIdQueryHandler : QueryHandlerAsync<GetRelationshipByIdQuery, RelationshipModel>
    {
        private readonly IDictionaryDatabase _database;

        public GetRelationshipByIdQueryHandler(IDictionaryDatabase database)
        {
            _database = database;
        }

        public override async Task<RelationshipModel> ExecuteAsync(GetRelationshipByIdQuery query, CancellationToken cancellationToken = new CancellationToken())
        {
            var relation = await _database.WordRelation.SingleOrDefaultAsync(r => r.Id == query.RelationshipId, cancellationToken);
            return relation.Map<WordRelation, RelationshipModel>();
        }
    }
}