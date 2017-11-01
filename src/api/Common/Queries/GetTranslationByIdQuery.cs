using Inshapardaz.Desktop.Common.Models;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Common.Queries
{
    public class GetTranslationByIdQuery : IQuery<TranslationModel>
    {
        public int TranslationId { get; set; }

        public int DictionaryId { get; set; }
    }
}