using Inshapardaz.Desktop.Common.Models;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Common.Queries
{
    public class GetWordsByDictionaryIdQuery : IQuery<PageModel<WordModel>>
    {
        public int DictionaryId { get; set; }
        public int PageNumber { get; set; } = 1;

        public int PageSize { get; set; } = 10;
    }
}