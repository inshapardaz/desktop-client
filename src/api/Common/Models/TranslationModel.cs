using System.Collections.Generic;

namespace Inshapardaz.Desktop.Common.Models
{
    public class TranslationModel
    {
        public long Id { get; set; }

        public string Language { get; set; }

        public int LanguageId { get; set; }

        public IEnumerable<LinkModel> Links { get; set; }

        public string Value { get; set; }

        public long WordDetailId { get; set; }
    }
}