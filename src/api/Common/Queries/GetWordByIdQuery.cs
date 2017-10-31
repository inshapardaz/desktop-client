using Inshapardaz.Desktop.Common.Models;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Common.Queries
{
    public class GetWordByIdQuery : IQuery<WordModel>
    {
        public int WordId { get; set; }

        public int DictionaryId { get; set; }
    }
}