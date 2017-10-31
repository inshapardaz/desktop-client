using System.Collections.Generic;
using Inshapardaz.Desktop.Common.Models;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Common.Queries
{
    public class GetTranslationsByWordDetailIdQuery : IQuery<IEnumerable<TranslationModel>>
    {
        public int DetailId { get; set; }

        public int DictionaryId { get; set; }
    }
}