using System.Collections.Generic;

namespace Inshapardaz.Desktop.Api.Models
{
    public class RelationshipView
    {
        public long Id { get; set; }

        public long SourceWordId { get; set; }

        public string SourceWord { get; set; }

        public long RelatedWordId { get; set; }

        public string RelatedWord { get; set; }

        public string RelationType { get; set; }

        public int RelationTypeId { get; set; }

        public IEnumerable<LinkView> Links { get; set; }
    }
}