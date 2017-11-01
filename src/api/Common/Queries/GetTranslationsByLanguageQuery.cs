using System.Collections.Generic;
using Inshapardaz.Desktop.Common.Models;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Common.Queries
{
    public class GetTranslationsByLanguageQuery : IQuery<IEnumerable<TranslationModel>>
    {
        public int WordId { get; set; }
        public LanguageType Language { get; set; }

        public int DictionaryId { get; set; }
    }
}