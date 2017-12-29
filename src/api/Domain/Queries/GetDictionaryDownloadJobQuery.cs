using Paramore.Darker;

namespace Inshapardaz.Desktop.Domain.Queries
{
    public class GetDictionaryDownloadJobQuery : IQuery<bool>
    {
        public GetDictionaryDownloadJobQuery(int dictionaryId)
        {
            DictionaryId = dictionaryId;
        }

        public int DictionaryId { get; private set; }
    }
}
