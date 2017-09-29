using System.Collections.Generic;

namespace Inshapardaz.Desktop.Common.Models
{
    public class WordModel
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public string TitleWithMovements { get; set; }

        public string Description { get; set; }

        public IEnumerable<LinkModel> Links { get; set; }

        public string Pronunciation { get; set; }

        public int DictionaryId { get; set;}
    }
}