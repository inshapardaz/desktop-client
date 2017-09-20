using System.Collections.Generic;
using Inshapardaz.Desktop.Common.Models;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Common.Queries
{
    public class GetRelationshipsByWordIdQuery : IQuery<IEnumerable<RelationshipModel>>
    {
        public int Id { get; set; }
    }
}