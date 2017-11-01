using System.Collections.Generic;

namespace Inshapardaz.Desktop.Api.Model
{
    public class WordView
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public string TitleWithMovements { get; set; }

        public string Description { get; set; }

        public string Attributes { get; set; }

        public int AttributeValue { get; set; }

        public string Language { get; set; }

        public int LanguageId { get; set; }

        public IEnumerable<LinkView> Links { get; set; }

        public string Pronunciation { get; set; }
    }
}