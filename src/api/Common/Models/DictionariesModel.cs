using System.Collections.Generic;

namespace Inshapardaz.Desktop.Common.Models
{
    public class DictionariesModel
    {
        public IEnumerable<LinkModel> Links { get; set; }

        public IEnumerable<DictionaryModel> Items { get; set; }
    }
}