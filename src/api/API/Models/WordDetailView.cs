using System;
using System.Collections.Generic;
using System.Text;

namespace Inshapardaz.Desktop.Api.Models
{
    public class WordDetailView
    {
        public long Id { get; set; }

        public string Attributes { get; set; }

        public int AttributeValue { get; set; }

        public string Language { get; set; }

        public int LanguageId { get; set; }

        public long WordId { get; set; }

        public IEnumerable<LinkView> Links { get; set; }
    }
}