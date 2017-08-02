using Inshapardaz.Desktop.Common.Models;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Common.Queries
{
    public class GetRelationshipByIdQuery : IQuery<RelationshipView>
    {
        public int Id { get; set; }
    }
}