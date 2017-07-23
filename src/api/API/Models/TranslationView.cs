using System;
using System.Collections.Generic;
using System.Text;

namespace Inshapardaz.Desktop.Api.Models
{
    public class TranslationView
    {
        public long Id { get; set; }

        public string Language { get; set; }

        public int LanguageId { get; set; }

        public IEnumerable<LinkView> Links { get; set; }

        public string Value { get; set; }

        public long WordId { get; set; }
    }
}