using Inshapardaz.Desktop.Common.Models;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Common.Queries
{
    public class SearchWordsByTitleQuery : IQuery<PageModel<WordModel>>
    {
        public int PageNumber { get; set; } = 1;

        public int PageSize { get; set; } = 10;

        public string Title { get; set; }

        public int DictionaryId { get; set; }
    }
}