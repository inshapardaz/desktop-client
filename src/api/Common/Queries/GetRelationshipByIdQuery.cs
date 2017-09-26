using Inshapardaz.Desktop.Common.Models;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Common.Queries
{
    public class GetRelationshipByIdQuery : IQuery<RelationshipModel>
    {
        public int RelationshipId { get; set; }
    }
}