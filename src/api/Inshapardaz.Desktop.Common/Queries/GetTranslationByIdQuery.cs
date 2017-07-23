using Inshapardaz.Desktop.Common.Models;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Common.Queries
{
    public class GetTranslationByIdQuery : IQuery<TranslationView>
    {
        public int Id { get; set; }
    }
}