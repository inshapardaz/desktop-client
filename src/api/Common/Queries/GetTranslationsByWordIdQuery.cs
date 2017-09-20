using System.Collections.Generic;
using Inshapardaz.Desktop.Common.Models;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Common.Queries
{
    public class GetTranslationsByWordIdQuery : IQuery<IEnumerable<TranslationModel>>
    {
        public int Id { get; set; }
    }
}