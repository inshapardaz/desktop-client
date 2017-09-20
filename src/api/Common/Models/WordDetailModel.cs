using System.Collections.Generic;

namespace Inshapardaz.Desktop.Common.Models
{
    public class WordDetailModel
    {
        public long Id { get; set; }

        public string Attributes { get; set; }

        public int AttributeValue { get; set; }

        public string Language { get; set; }

        public int LanguageId { get; set; }

        public long WordId { get; set; }

        public IEnumerable<LinkModel> Links { get; set; }
    }
}