using System.Collections.Generic;
using Inshapardaz.Desktop.Common.Models;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Common.Queries
{
    public class GetTranslationsByLanguageQuery : IQuery<IEnumerable<TranslationView>>
    {
        public int Id { get; set; }
        public LanguageType Language { get; set; }
    }
}