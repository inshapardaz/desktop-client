using System.Collections.Generic;

namespace Inshapardaz.Desktop.Common.Models
{
    public class DictionaryModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Language { get; set; }

        public string UserId { get; set; }

        public bool IsPublic { get; set; }

        public bool IsOffline { get; set; }

        public long WordCount { get; set; }

        public IEnumerable<LinkModel> Links { get; set; }

        public IEnumerable<LinkModel> Indexes { get; set; }
        public bool IsDownloading { get; set; }
    }
}