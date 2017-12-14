using Inshapardaz.Desktop.Common.Models;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Common.Queries
{
    public class GetLocalDictionaryQuery : IQuery<DictionaryModel>
    {
        public int DictionaryId { get; set; }
    }
}